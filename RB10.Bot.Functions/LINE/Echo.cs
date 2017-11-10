using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

namespace RB10.Bot.Functions.LINE
{
    public static class Echo
    {
        [FunctionName("Echo")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("Start");

            // ���N�G�X�gJSON���p�[�X
            string jsonContent = await req.Content.ReadAsStringAsync();
            Request data = JsonConvert.DeserializeObject<Request>(jsonContent);

            string replyToken = null;
            string messageType = null;
            string echoWord = null;

            // WebApps�̃v���p�e�B�ݒ肩��f�[�^���擾
            var channelAccessToken = ConfigurationManager.AppSettings["AccessToken"];

            // ���N�G�X�g�f�[�^����f�[�^���擾
            foreach (var item in data.events)
            {
                // ���v���C�f�[�^���t���̔F�؃g�[�N�����擾
                replyToken = item.replyToken.ToString();
                if (item.message != null)
                {
                    // ���b�Z�[�W�^�C�v���擾�A�e�L�X�g�ȊO�̓G���[������ԋp
                    messageType = item.message.type.ToString();
                    if (item.message.text != null)
                    {
                        echoWord = item.message.text.ToString();
                    }
                }
            }

            // ���v���C�f�[�^�̍쐬
            var content = CreateResponse(replyToken, echoWord, log, messageType);

            // JSON�`���ɕϊ�
            var reqData = JsonConvert.SerializeObject(content);

            // ���X�|���X�̍쐬
            using (var client = new HttpClient())
            {
                // ���N�G�X�g�f�[�^���쐬
                // ��HttpClient��[application/json]��HTTP�w�b�_�ɒǉ�����Ƃ��͉��L�̃R�[�f�B���O����Ȃ��ƃG���[�ɂȂ�
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://api.line.me/v2/bot/message/reply")
                {
                    Content = new StringContent(reqData, Encoding.UTF8, "application/json")
                };

                //�@�F�؃w�b�_�[��ǉ�
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {channelAccessToken}");

                // �񓯊���POST
                var res = await client.SendAsync(request);

                return req.CreateResponse(res.StatusCode);
            }
        }

        /// <summary>
        /// ���v���C���̍쐬
        /// </summary>
        /// <param name="token"></param>
        /// <param name="praiseWord"></param>
        /// <param name="log"></param>
        /// <param name="messageType"></param>
        /// <returns></returns>
        static Response CreateResponse(string token, string praiseWord, TraceWriter log, string messageType = "")
        {
            Response res = new Response();
            Messages msg = new Messages();

            // ���v���C�g�[�N���̓��N�G�X�g�Ɋ܂܂�郊�v���C�g�[�N�����g��
            res.replyToken = token;
            res.messages = new List<Messages>();

            // ���b�Z�[�W�^�C�v��text�ȊO�͒P��̃��X�|���X���Ƃ���
            if (messageType == "text")
            {
                msg.type = "text";
                msg.text = praiseWord;
                res.messages.Add(msg);

            }
            else
            {
                msg.type = "text";
                msg.text = "�e�L�X�g�ȊO�̓G�R�[�ł��Ȃ������I�I";
                res.messages.Add(msg);
            }

            return res;
        }


        //�@���N�G�X�g
        public class Request
        {
            public List<Event> events { get; set; }
        }

        //�@�C�x���g
        public class Event
        {
            public string replyToken { get; set; }
            public string type { get; set; }
            public object timestamp { get; set; }
            public Source source { get; set; }
            public message message { get; set; }
        }

        // �\�[�X
        public class Source
        {
            public string type { get; set; }
            public string userId { get; set; }
        }

        // ���N�G�X�g���b�Z�[�W
        public class message
        {
            public string id { get; set; }
            public string type { get; set; }
            public string text { get; set; }
        }

        // ���X�|���X
        public class Response
        {
            public string replyToken { get; set; }
            public List<Messages> messages { get; set; }
        }

        // ���X�|���X���b�Z�[�W
        public class Messages
        {
            public string type { get; set; }
            public string text { get; set; }
        }
    }
}
