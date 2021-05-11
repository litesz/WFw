﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WFw.TencentCloud.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TencentCloud.Ocr.V20181119;
using TencentCloud.Common;
using TencentCloud.Ocr.V20181119.Models;
using System.Threading.Tasks;

namespace WFw.TencentCloud.Clients.Ocr
{

    public interface IWFwOcrClient
    {

        Task<BizLicenseOCRResponse> BizLicenseOCR(string imageUrl);
    }

    public class WFwOcrClient : IWFwOcrClient
    {

        private readonly ILogger<WFwOcrClient> logger;
        private readonly OcrOptions ocrOptions;
        private readonly OcrClient client;

        public WFwOcrClient(IServiceProvider sp) : this(sp.GetService<IOptions<TencentCloudOptions>>().Value.Ocr, sp.GetService<ILogger<WFwOcrClient>>())
        {
        }

        public WFwOcrClient(OcrOptions ocr, ILogger<WFwOcrClient> l)
        {
            ocrOptions = ocr;
            logger = l;

            Credential cred = new Credential
            {
                SecretId = ocr.SecretId,
                SecretKey = ocr.SecretKey
            };

            client = new OcrClient(cred, "ap-guangzhou");
        }



        public async Task<BizLicenseOCRResponse> BizLicenseOCR(string imageUrl)
        {
            try
            {
                return await client.BizLicenseOCR(new BizLicenseOCRRequest
                {
                    ImageUrl = imageUrl
                });

            }
            catch (TencentCloudSDKException tce)
            {

            }
            catch (Exception ex)
            {


            }

            return null;
        }

    }
}
