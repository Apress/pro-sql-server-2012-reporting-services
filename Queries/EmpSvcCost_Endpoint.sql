IF EXISTS 
(
      SELECT name from sys.http_endpoints 
      WHERE name =  'EmpSvcCost'
)
      DROP ENDPOINT  EmpSvcCost
GO
Create ENDPOINT empsvccost
AUTHORIZATION sa
STATE = Started
AS HTTP 
(
PATH = '/SQL/empsvccost',
Authentication = (Integrated),
PORTS=(CLEAR),
SITE = '*'
)

For SOAP
(
WEBMETHOD 'http://tempuri.org/'.'empsvccost' 
(name='pro_srs.dbo.emp_svc_cost',SCHEMA = STANDARD),
WSDL = DEFAULT,
BATCHES=ENABLED,
DATABASE='pro_srs'
)
