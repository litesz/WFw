### 0.0.9
* WFwException
	+ ���������Ϣ��Exception.Data
* BadRequestException
	- ɾ��Ĭ�Ϲ��캯��
	+ Ĭ�ϴ������͸�Ϊ OperationResultType.ParamIsErr
### 0.0.8
 * ErrApiResult
	+ �����ΪApiResultBase
	- ɾ��RequestId
 ���� ModelStateErrApiResult
 ���� IApiResult
 ���� IErrApirResult 
 ���� ApiResultBase
 ���� AutoExtensions
 ���� FormatExtensions
 ���� RandomExtensions
 ���� StringExtensions
 ���� TimeStampExtenisons
 ���� ValidateExtenisons
 ���� EncryptProvider
 ���� IdProvider
 ���� StringEncryptProvider
 

### 0.0.7
 * ApiResult
	+ ��� ApiResult(OperationResultType code, T data)
 * ErrApiResult
	+ ��� public ErrApiResult(string msg) : this("", OperationResultType.IsErr, msg)
 * ExceptionExtensions
	+ �޸� ToLogMessage ���Ĭ�ϲ��� string spiltStr = "\r\n"
 * WFwException
	+ ���EVENTID
 * WFwNotExistException
	+ ���EVENTID
 * WFwIsExistException
	+ ���EVENTID
 * WFwIsEmptyException
	+ ���EVENTID

### 0.0.6
 * JsonExtensions
	+ ��� Serialize<T>(this T entity, bool isIgnoreNull)
 * WFwException
	+ ��� WFwException(OperationResultType result, string param, params string[] logKeyValues) 
 * ���� WFwIsEmptyException 
 * ���� WFwNotExistException 
 * ���� WFwIsExistException 

### 0.0.5
������ ErrApirResult Ϊ ErrApiResult
�޸� ApiResult������

### 0.0.4
�޸� OperationResultType ö��ֵ
�޸� WFwException ���캯��,���LogParam
�޸� BadRequestException���캯��
�޸� ApiResult������
��� ErrApirResult
��� ExceptionExtensions

### 0.0.3
����readme
���apiResult���Գ�ͻ 