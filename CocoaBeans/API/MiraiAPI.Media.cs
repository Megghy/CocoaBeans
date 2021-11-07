// Copyright (c) Maila. All rights reserved.
// Licensed under the GNU AGPLv3

using Maila.Cocoa.Beans.Exceptions;
using Maila.Cocoa.Beans.Models.Messages;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maila.Cocoa.Beans.API
{
    public static partial class MiraiAPI
    {
        /// <summary>Upload image files to the server.</summary>
        /// <exception cref="MiraiException" />
        /// <exception cref="WebException" />
        public static async Task<IImageMessage> UploadImage(string host, string sessionKey, UploadType type, Stream imgStream)
        {
            MultipartFormDataContent content = new();

            StringContent _skey = new(sessionKey);
            _skey.Headers.ContentDisposition = new("form-data") { Name = "sessionKey" };
            content.Add(_skey);

            StringContent _type = new(type.ToString().ToLower());
            _type.Headers.ContentDisposition = new("form-data") { Name = "type" };
            content.Add(_type);
            imgStream.Position = 0L;
            using Image img = Image.Load(imgStream, out IImageFormat format);
            using MemoryStream ms = new();
            img.SaveAsPng(ms);
            ms.Seek(0, SeekOrigin.Begin);
            using StreamContent _img = new(ms);
            string formatString = format.Name.ToLower().Replace("jpeg", "jpg");
            _img.Headers.ContentDisposition = new("form-data")
            {
                Name = "img",
                FileName = $"{Guid.NewGuid():n}.{formatString}"
            };
            _img.Headers.ContentType = new($"image/{formatString}");
            content.Add(_img);

            using HttpClient client = new();
            using HttpResponseMessage respMsg = await client.PostAsync($"http://{host}/uploadImage", content);

            JsonElement res;
            if (!respMsg.IsSuccessStatusCode)
            {
                throw new WebException(respMsg.ReasonPhrase);
            }

            res = JsonDocument.Parse(await respMsg.Content.ReadAsStringAsync()).RootElement;
            return ImageMessage.Parse(res) ?? throw new Exception("Invalid response.");
        }

        /// <summary>Upload voice files to the server.</summary>
        /// <exception cref="MiraiException" />
        /// <exception cref="WebException" />
        public static async Task<IVoiceMessage> UploadVoice(string host, string sessionKey, Stream voiceStream)
        {
            MultipartFormDataContent content = new();

            StringContent _skey = new(sessionKey);
            _skey.Headers.ContentDisposition = new("form-data") { Name = "sessionKey" };
            content.Add(_skey);

            StringContent _type = new("group");
            _type.Headers.ContentDisposition = new("form-data") { Name = "type" };
            content.Add(_type);

            StreamContent _voice = new(voiceStream);
            _voice.Headers.ContentDisposition = new("form-data")
            {
                Name = "voice",
                FileName = $"{Guid.NewGuid():n}.amr"
            };
            content.Add(_voice);

            using HttpClient client = new();
            using HttpResponseMessage respMsg = await client.PostAsync($"http://{host}/uploadVoice", content);

            JsonElement res;
            if (!respMsg.IsSuccessStatusCode)
            {
                throw new WebException(respMsg.StatusCode.ToString());
            }

            res = JsonDocument.Parse(await respMsg.Content.ReadAsStringAsync()).RootElement;
            return VoiceMessage.Parse(res) ?? throw new Exception("Invalid response.");
        }

        /// <summary>Upload files to group.</summary>
        /// <exception cref="MiraiException" />
        /// <exception cref="WebException" />
        public static async Task<string> UploadFileAndSend(string host, string sessionKey, long groupId, string path, Stream fileStream)
        {
            MultipartFormDataContent content = new();

            StringContent _skey = new(sessionKey);
            _skey.Headers.ContentDisposition = new("form-data") { Name = "sessionKey" };
            content.Add(_skey);

            StringContent _type = new("Group");
            _type.Headers.ContentDisposition = new("form-data") { Name = "type" };
            content.Add(_type);

            StringContent _target = new(groupId.ToString());
            _target.Headers.ContentDisposition = new("form-data") { Name = "target" };
            content.Add(_target);

            StringContent _path = new(path);
            _path.Headers.ContentDisposition = new("form-data") { Name = "path" };
            content.Add(_path);

            StreamContent _voice = new(fileStream);
            _voice.Headers.ContentDisposition = new("form-data") { Name = "file" };
            content.Add(_voice);

            using HttpClient client = new();
            using HttpResponseMessage respMsg = await client.PostAsync($"http://{host}/uploadFileAndSend", content);

            JsonElement res;
            if (!respMsg.IsSuccessStatusCode)
            {
                throw new WebException(respMsg.StatusCode.ToString());
            }

            res = JsonDocument.Parse(await respMsg.Content.ReadAsStringAsync()).RootElement;
            int code = res.GetCode();
            if (code != 0)
            {
                throw new MiraiException(code);
            }

            return res.GetProperty("id").GetString() ?? throw new Exception("Invalid response.");
        }
    }

    public enum UploadType
    {
        Friend,
        Group,
        Temp
    }
}
