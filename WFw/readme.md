### 1.2.10
* 包
 升级至2.1

### 1.2.9
 * IWQueryable
  + 添加 GroupBy
 * DefaultRepository
  + 改为虚方法
 -  DefaultRepository<TEntity>
 * 删除 CheckParams
 * 新增 PagedResponseDataWithTimeStampDto
 * 新增 IPagedResponseDataWithTimeStampDto
 * 新增 IResponseDataWithTimeStampDto
 * 新增 SmsExtensions
 * 重构 注入改为TryXXXX


### 1.2.8
 * Repository 可独立设置审计用户id类型

### 1.2.7
 * 修复使用scope注入时，审计接口失败

### 1.2.6
 * 拆分接口 ISoftDeletableFlag
 * DefaultRepository
	+ Init 接口可初始化数据
 * IWQueryable
	+ OrderByDescending
	+ OrderByDescendingIF
 * 新增 ConfigureModelStateResponse
 * 新增 HttpHeaderConst
 * 新增 WFwApiResult
 * 新增 WFwErrApiResult
 * 新增 RequestDto
 * WFwErrorHandlingMiddleware 
	+ request header添加 x-wfw-requestId
	+ response header添加 x-wfw-requestId
 * IRequestDto
	+   (bool isOk, string errMsg) ValidateParams()

### 1.2.5

#####  功能
 * LimitedResultRequestDto
	+ 修改maxPageSize为100
 * PagedResponseDataDto
	+ 添加构造函数
 * WFwErrorHandlingMiddleware
	+ wfw为Unauthorized时，返回 StatusCode 401

#####  BUG
 * WFwErrorHandlingMiddleware
	+ 修复记录BUG


### 1.2.4
 * WFwErrorHandlingMiddleware
	修改 requestid 为context.TraceIdentifier

### 1.2.3
 * UserClaimTypes 新增
 * CurrentUser
	+ 修改字符串为常量


### 1.2.2 待提交
修改 WFwErrorHandlingMiddleware


### 1.2.1 待提交
修改 WFwErrorHandlingMiddleware

### 1.2.0
创建readme
添加ISmsClient接口