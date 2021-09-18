### 1.0.1
 * 断崖式更新
 * 重构 SmsChineseApiClient
 * SmsChineseOptions
	- 移除IsUtf8选项
	- 移除ILogger
	+ VerificationCodeTemplate
	+ GetSendMsgUrl(string smsMob, string smsText)
	+ GetMessageRemainingUrl()
### 1.0.0
创建readme
实现查询剩余短信条数