### 1.2.10
* ��
 ������2.1

### 1.2.9
 * IWQueryable
  + ��� GroupBy
 * DefaultRepository
  + ��Ϊ�鷽��
 -  DefaultRepository<TEntity>
 * ɾ�� CheckParams
 * ���� PagedResponseDataWithTimeStampDto
 * ���� IPagedResponseDataWithTimeStampDto
 * ���� IResponseDataWithTimeStampDto
 * ���� SmsExtensions
 * �ع� ע���ΪTryXXXX


### 1.2.8
 * Repository �ɶ�����������û�id����

### 1.2.7
 * �޸�ʹ��scopeע��ʱ����ƽӿ�ʧ��

### 1.2.6
 * ��ֽӿ� ISoftDeletableFlag
 * DefaultRepository
	+ Init �ӿڿɳ�ʼ������
 * IWQueryable
	+ OrderByDescending
	+ OrderByDescendingIF
 * ���� ConfigureModelStateResponse
 * ���� HttpHeaderConst
 * ���� WFwApiResult
 * ���� WFwErrApiResult
 * ���� RequestDto
 * WFwErrorHandlingMiddleware 
	+ request header��� x-wfw-requestId
	+ response header��� x-wfw-requestId
 * IRequestDto
	+   (bool isOk, string errMsg) ValidateParams()

### 1.2.5

#####  ����
 * LimitedResultRequestDto
	+ �޸�maxPageSizeΪ100
 * PagedResponseDataDto
	+ ��ӹ��캯��
 * WFwErrorHandlingMiddleware
	+ wfwΪUnauthorizedʱ������ StatusCode 401

#####  BUG
 * WFwErrorHandlingMiddleware
	+ �޸���¼BUG


### 1.2.4
 * WFwErrorHandlingMiddleware
	�޸� requestid Ϊcontext.TraceIdentifier

### 1.2.3
 * UserClaimTypes ����
 * CurrentUser
	+ �޸��ַ���Ϊ����


### 1.2.2 ���ύ
�޸� WFwErrorHandlingMiddleware


### 1.2.1 ���ύ
�޸� WFwErrorHandlingMiddleware

### 1.2.0
����readme
���ISmsClient�ӿ�