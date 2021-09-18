### 0.0.10
* 重构 WFwSmsClient
* 重构 注入改为TryXXXX

### 0.0.9
* 更新 Tencent Sdk
* 将异常抛出

### 0.0.8
 * IWFwStsClient
	+ 添加  TempCredentialResult GetDefaultTempCredential(string bucket, string region, string allowPrefix, int durationSeconds = 7200)
	+ GetTempCredential 添加守卫验证
	+ GenTempCredential 修改错误日志
 * 新增 WFwTencentCloudSdkException 
 * 新增 WFwTencentCloudSdkStsException 

### 0.0.7
添加 WFwOcrClient
修改 WFwSmsClient 错误记录
修改 WFwCosClient 错误记录

### 0.0.6
创建readme
添加WFwStsClient