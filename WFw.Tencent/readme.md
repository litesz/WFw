
### 0.0.5
 * TencentHttpException
	+ 修改引用
	+ 添加构造函数
 * BaseTencentApiHttpClient
	+ 添加 Task<T> Put<T>(string url, string putData) where T : BaseResponse
	+ 添加 Task<T> Put<T>(string url, object data) where T : BaseResponse

### 0.0.4
创建readme
添加部分错误信息