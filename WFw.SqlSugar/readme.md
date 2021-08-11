### 1.1.15
 * IWQueryable
  + 添加 GroupBy
### 1.1.14
 * Repository 可独立设置审计用户id类型
### 1.1.13
---- 
#####  功能
 * 适配部分efcore特性标签
#####  BUG
 * 修复主键类型为string时，updateUserId和deleteUserId不能为空的错误

### 1.1.12
---- 
#####  BUG
 * 修复FullAuditByUserEntityBase 名称

### 1.1.11
---- 
#####  功能
 * 修改ISqlSugarDbContext和IWDbContext为同一实例
 * 添加 DbContext/Extensions
 * 添加 DbContext/QueryExtensions
 * 移除 扩展ToISugarQueryable
	

### 1.1.10
添加 IRepository 扩展ToISugarQueryable

### 1.1.9
添加 AddWFwSqlSugarDbContext 中间件
添加 ISqlSugarDbContext
更新 sqlsugarcore 至5.3.0
### 1.1.8
创建readme
更新版本