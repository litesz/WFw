### 0.0.7
 * ApiResult
	+ 添加 ApiResult(OperationResultType code, T data)
 * ErrApiResult
	+ 添加 public ErrApiResult(string msg) : this("", OperationResultType.IsErr, msg)
 * ExceptionExtensions
	+ 修改 ToLogMessage 添加默认参数 string spiltStr = "\r\n"

### 0.0.6
 * JsonExtensions
	+ 添加 Serialize<T>(this T entity, bool isIgnoreNull)
 * WFwException
	+ 添加 WFwException(OperationResultType result, string param, params string[] logKeyValues) 
 * 新增 WFwIsEmptyException 
 * 新增 WFwNotExistException 
 * 新增 WFwIsExistException 

### 0.0.5
重命名 ErrApirResult 为 ErrApiResult
修改 ApiResult及泛型

### 0.0.4
修改 OperationResultType 枚举值
修改 WFwException 构造函数,添加LogParam
修改 BadRequestException构造函数
修改 ApiResult及泛型
添加 ErrApirResult
添加 ExceptionExtensions

### 0.0.3
创建readme
解决apiResult属性冲突 