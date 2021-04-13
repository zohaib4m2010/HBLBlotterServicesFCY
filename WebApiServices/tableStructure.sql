--Drop Table if exists  SBP_LoginInfo;
CREATE TABLE [dbo].[SBP_LoginInfo](
	[Id] [int] identity  NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](260) NULL,
	[ContactNo] [nvarchar](12) NULL, 
	[Email] [nvarchar](50) NULL, 
	[LastLoginDate] [datetime] NULL,
	[LoginFailedCount] [int] NULL,
	[LoginIPAddress] [nvarchar](20) NULL,
	[CustomerTimeZone] [nvarchar](20) NULL,
	[LastAccessedDate] [datetime] NULL,
	[AccountLocked] [bit] NULL,
	[BranchID] int not NULL,
	[isActive] bit,
	[CreateDate] datetime,
	[UpdateDate] datetime,
	Constraint PK_SBP_LoginInfo primary key clustered(ID)
)

--alter table [SBP_LoginInfo] 
--add isConventional bit 
--alter table [SBP_LoginInfo] 
--add isislamic bit 

--update [SBP_LoginInfo] set isConventional=1,isislamic=0


select* From [SBP_LoginInfo] where UserName='Wasim' and Password='rKVDpGilJ0sGHalu0U4bhA==' and isActive=1



--delete from [SBP_LoginInfo] where Id>18

--Drop Table if exists  Branches;
create table Branches(
BID int identity not null,
BranchCode  nvarchar(20) null,
BranchName nvarchar(30) null,
BrachDescription nvarchar(250) null,
BranchLocation nvarchar(30) null,
isActive bit,
CreateDate datetime,
UpdateDate datetime,
Constraint PK_Branches primary key clustered(BID)
)

select* From Branches




--Drop Table if exists  Currencies
create table Currencies(
CID int identity not null,
Symbol varchar(5),
Currency varchar(20),
Country varchar(20),
isActive bit,
CreateDate datetime,
UpdateDate datetime,
Constraint PK_Currencies primary key clustered(CID)
)

--insert into Currencies(Symbol,Currency,Country,isActive,CreateDate) values('PKR','Pak Rupee','Pakistan',1,GETDATE())
--insert into Currencies(Symbol,Currency,Country,isActive,CreateDate) values('USD','US Dollar','United States',1,GETDATE())

--Drop Table if exists  UserCurrencyRelation
create table UserCurrencyRelation(
UCRID int identity not null,
UserID int not null Constraint FK_UserCurrencyRelation_UserID Foreign key References SBP_LoginInfo(ID),
CID int not null Constraint FK_UserCurrencyRelation_CID Foreign key References Currencies(CID),
)

--insert into UserCurrencyRelation(UserID,CID) values(10,1)
--insert into UserCurrencyRelation(UserID,CID) values(10,2)

--Drop Table if exists  UserRole;
create table UserRole(
URID int identity not null,
RoleName  nvarchar(20) null,
RoleDescription nvarchar(250) null,
isActive bit,
CreateDate datetime,
UpdateDate datetime,
Constraint PK_UserRole primary key  clustered(URID)
)

--Drop Table if exists  UserRoleRelation;
create table UserRoleRelation
(
URRID int primary key identity not null,
UserId int not null Constraint FK_URRUserID Foreign key References SBP_LoginInfo(ID),
URID int not null COnstraint FK_URURID Foreign key References UserRole(URID),
)

select * from UserRoleRelation


--Drop Table if exists  WebPages;
create table WebPages
(
WPID int identity not null,
PageName  varchar(20) null,
ControllerName varchar(20) null,
DisplayName  varchar(20) null,
PageDescription nvarchar(250) null,
isActive bit,
CreateDate datetime,
UpdateDate datetime,
Constraint Pages primary key  clustered (WPID)
)

select* From WebPages

--insert into WebPages(PageName,ControllerName,DisplayName,isActive,CreateDate) values('BlotterTBO','BlotterTBO', 'Blotter TBO',1,GETDATE())
--insert into WebPages(PageName,ControllerName,DisplayName,isActive,CreateDate) values('BlotterClearing','BlotterClearing', 'Blotter Clearing',1,GETDATE())
--insert into WebPages(PageName,ControllerName,DisplayName,isActive,CreateDate) values('BlotterTrade','BlotterTrade', 'Blotter Trade',1,GETDATE())
--insert into WebPages(PageName,ControllerName,DisplayName,isActive,CreateDate) values('BlotterCRRFINCON','BlotterCRRFINCON', 'Blotter CRRFINCON',1,GETDATE())
--insert into WebPages(PageName,ControllerName,DisplayName,isActive,CreateDate) values('NostroBanks','NostroBanks', 'Nostro Banks',1,GETDATE())
--insert into WebPages(PageName,ControllerName,DisplayName,isActive,CreateDate) values('BlotterBreakups','BlotterBreakups', 'Blotter Breakups',1,GETDATE())


--Drop Table if exists  UserPageRelation;
create table UserPageRelation
(
UPRID  int primary key clustered identity not null,
URID int not null Constraint FK_UPRUserRoleID Foreign key References UserRole(URID),
WPID int not null Constraint FK_URRWPID Foreign key References WebPages(WPID),
DateChangeAccess bit,
EditAccess bit,
DeleteAccess bit
)
select* From UserPageRelation
--insert into UserPageRelation(URID,WPID,DateChangeAccess,EditAccess,DeleteAccess) VALUES(1,3,1,1,1)
--insert into UserPageRelation(URID,WPID,DateChangeAccess,EditAccess,DeleteAccess) VALUES(1,4,1,1,1)
--insert into UserPageRelation(URID,WPID,DateChangeAccess,EditAccess,DeleteAccess) VALUES(1,5,1,1,1)
--insert into UserPageRelation(URID,WPID,DateChangeAccess,EditAccess,DeleteAccess) VALUES(1,6,1,1,1)
--insert into UserPageRelation(URID,WPID,DateChangeAccess,EditAccess,DeleteAccess) VALUES(1,7,1,1,1)
--insert into UserPageRelation(URID,WPID,DateChangeAccess,EditAccess,DeleteAccess) VALUES(1,8,1,1,1)


--Drop Table if exists  SBP_BlotterTransactionTitles;
create table SBP_BlotterTransactionTitles(
TTID int identity not null,
TranctionTitle nvarchar(50),
TranctionDescription nvarchar(50),
Transactionfor nvarchar(50),
isActive bit,
CreateDate datetime,
UpdateDate datetime,
Constraint PK_TTiD primary key  clustered (TTID)
)

select * from SBP_BlotterTransactionTitles


--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Cash','TBO',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('TT Via SBP','TBO',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('TT Via NBP','TBO',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('TT Via Other Banks','TBO',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Interswitch Payments/Penalty/ Others','TBO',1,GETDATE())



--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Normal','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Same Day','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Special','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Intercity','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Clearing Return','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Other','Clearing',1,GETDATE())



--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Re-Finance Part','Trade',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Customer Transfer','Trade',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Other','Trade',1,GETDATE())


--Drop Table  SBP_BlotterTBO;
create table SBP_BlotterTBO
(
SNo bigint identity not null,
TTID int not null Constraint FK_SBP_BlotterTBO_TTID Foreign key References SBP_BlotterTransactionTitles(TTID),
TBO_Date DATETIME,
TBOCOde nvarchar(20),
TBO_InFlow numeric,
TBO_OutFLow numeric,
Note nvarchar(250),
UserID int not null Constraint FK_SBP_BlotterTBO_UserID Foreign key References SBP_LoginInfo(ID),
CreateDate DATETIME,
UpdateDate DATETIME,
BR int not null,
BID int not null Constraint FK_SBP_BlotterTBO_BranchID Foreign key References Branches(BID),
CurID int not null Constraint FK_SBP_BlotterTBO_CurID Foreign key References Currencies(CID),
Flag varchar(2),
Constraint PKTBO_SNo primary key  clustered (Sno))


select* from SBP_BlotterTBO


--drop proc SP_GetAll_SBPBlotterTBO
Create proc SP_GetAll_SBPBlotterTBO(@UserID int,@BranchID int,@CurID int,@BR int)
as
Begin
select TBO.SNo,TBO.TTID,TT.TranctionTitle TransactionType,TBO.TBO_Date,TBOCOde,TBO_InFlow,TBO.TBO_OutFLow,TBO.Note,TBO.CreateDate,TBO.UpdateDate,TBO.BR,TBO.CurID,TBO.Flag 
From SBP_BlotterTBO TBO inner join SBP_BlotterTransactionTitles TT on TBO.TTID=TT.TTID
where TBO.UserID=@UserID and TBO.BR=@BR and BID=@BranchID and TBO.CurID=@CurID
end


--Drop proc if exists SP_GETAllTBOTransactionTitles
create proc SP_GETAllTBOTransactionTitles
as
Begin

select TTID,TranctionTitle From SBP_BlotterTransactionTitles where Transactionfor='TBO' and  isActive=1

End





--Drop Table  SBP_BlotterClearing;
create table SBP_BlotterClearing
(
SNo bigint identity not null,
TTID int not null Constraint FK_SBP_BlotterClearing_TID Foreign key References SBP_BlotterTransactionTitles(TTID),
Clearing_Date DATETIME,
ClearingCOde nvarchar(20),
Clearing_InFlow numeric,
Clearing_OutFLow numeric,
Note nvarchar(250),
UserID int not null Constraint FK_SBP_BlotterClearing_UserID Foreign key References SBP_LoginInfo(ID),
CreateDate DATETIME,
UpdateDate DATETIME,
BR int not null,
BID int not null Constraint FK_SBP_BlotterClearing_BranchID Foreign key References Branches(BID),
CurID int not null Constraint FK_SBP_BlotterClearing_CurID Foreign key References Currencies(CID),
Flag varchar(2),
Constraint PKClearing_SNo primary key  clustered (Sno))

select* From SBP_BlotterClearing

--drop proc SP_GetAll_SBPBlotterClearing
Create proc SP_GetAll_SBPBlotterClearing(@UserID int,@BranchID int,@CurID int,@BR int)
as
Begin
select Clearing.SNo,Clearing.TTID,TT.TranctionTitle TransactionType,Clearing.Clearing_Date,ClearingCOde,Clearing_InFlow,Clearing.Clearing_OutFLow,Clearing.Note,Clearing.CreateDate,Clearing.UpdateDate,Clearing.BR,Clearing.BID,Clearing.CurID,Clearing.Flag 
From SBP_BlotterClearing Clearing inner join SBP_BlotterTransactionTitles TT on Clearing.TTID=TT.TTID
where Clearing.UserID=@UserID and Clearing.BID=@BranchID and Clearing.CurID=@CurID and BR=@BR
end

--Drop proc if exists SP_GETAllClearingTransactionTitles
create proc SP_GETAllClearingTransactionTitles
as
Begin

select TTID,TranctionTitle From SBP_BlotterTransactionTitles where Transactionfor='Clearing' and  isActive=1

End

--Drop Table if exists  SBP_BlotterTrade;
create table SBP_BlotterTrade
(
SNo bigint identity not null,
TTID int not null Constraint FK_SBP_BlotterTrade_TID Foreign key References SBP_BlotterTransactionTitles(TTID),
Trade_Date DATETIME,
TradeCOde nvarchar(20),
Trade_InFlow numeric,
Trade_OutFLow numeric,
Note nvarchar(250),
UserID int not null Constraint FK_SBP_BlotterTrade_UserID Foreign key References SBP_LoginInfo(ID),
CreateDate DATETIME,
UpdateDate DATETIME,
BR int,
BID int not null Constraint FK_SBP_BlotterTrade_BranchID Foreign key References Branches(BID),
CurID int not null Constraint FK_SBP_BlotterTrade_CurID Foreign key References Currencies(CID),
Flag varchar(2),
Constraint PKTrade_SNo primary key  clustered (Sno))
select* From SBP_BlotterTrade

alter proc SP_GetAll_SBPBlotterTrade(@UserID int,@BranchID int,@CurID int,@BR int)
as
Begin
select Trade.SNo,Trade.TTID,TT.TranctionTitle TransactionType,Trade.Trade_Date,Trade.TradeCOde,Trade_InFlow,Trade.Trade_OutFLow,Trade.Note,Trade.CreateDate,Trade.UpdateDate,Trade.BR,Trade.BID,Trade.CurID,Trade.Flag 
From SBP_BlotterTrade Trade inner join SBP_BlotterTransactionTitles TT on Trade.TTID=TT.TTID
where Trade.UserID=@UserID and Trade.BID=@BranchID and BR=@BR and Trade.CurID=@CurID
end
--Drop proc if exists SP_GETAllTradeTransactionTitles
create proc SP_GETAllTradeTransactionTitles
as
Begin

select TTID,TranctionTitle From SBP_BlotterTransactionTitles where Transactionfor='Trade' and  isActive=1

End





--Drop Table  SBP_BlotterCRRFINCON
create table SBP_BlotterCRRFINCON(
SNo bigint identity not null,
StartDate DATETIME,
EndDate DATETIME,
DemandTimeLiablities  numeric,
TimeLiablitiesOverOneYear numeric,
DemandTimeLiablitiesTotal numeric,
PreMatureDeposit numeric,
DemandTimeLiablitiesTotalForCRR numeric,
Penalty numeric,
ExtraBenefits numeric,
CRR1Requirement numeric,
CRR2Requirement numeric,
RequirementPenalty numeric,
RequirementExtBenefit numeric,
BalMaintAgainstPenalty float,
BalMaintAgainstExtBenft float,
UserID int not null Constraint FK_SBP_BlotterCRRFINCON_UserID Foreign key References SBP_LoginInfo(ID),
CreateDate DATETIME,
UpdateDate DATETIME,
BR int not null,
BID int not null Constraint FK_BlotterCRRFINCON_BranchID Foreign key References Branches(BID),
CurID int not null Constraint FK_BlotterCRRFINCON_CurID Foreign key References Currencies(CID),
Flag varchar(2),
Constraint PK_BlotterCRRFINCON_SNo primary key  clustered (SNo))

select *,CRR2Requirement+Penalty,CRR2Requirement-ExtraBenefits,(0.05/cast(CRR2Requirement as float)*cast(RequirementPenalty as float))*100 from SBP_BlotterCRRFINCON 


--truncate table SBP_BlotterCRRFINCON

--Drop proc SP_GetSBPBlotterCRRFINCON
--create Proc SP_GetSBPBlotterCRRFINCON(@UserID int,@BranchID int ,@CurID int,@BR int)
--as
--select * from SBP_BlotterCRRFINCON where cast(StartDate as date) <= cast(GETDATE() as date) and cast(EndDate as date) >= cast(GETDATE() as date) and UserID=@UserID and BID=@BranchID and CurID=@CurID and BR=@BR 



--truncate table SBP_BlotterCRRFINCON

--Drop proc if exists SP_SBPGetLoginInfoById
--create proc SP_SBPGetLoginInfoById(@id int)
--as
--		SELECT 
--   ID,UserName,Email,c.RoleName,f.BID BranchID,f.BranchName,'Success' AS UserExists ,
--   STUFF((SELECT ', '  + cast(C.CID as nvarchar(5)) + '~' +C.Symbol
--          FROM UserCurrencyRelation CR inner join  Currencies C on CR.CID=C.CID
--          WHERE CR.UserID = a.ID and C.isActive=1
--          ORDER BY Symbol
--          FOR XML PATH('')), 1, 1, '') [Currencies],
--   STUFF((SELECT ', ' + US.DisplayName +'~' + US.PageName  + '~'+US.ControllerName+'~'+cast(USS.DateChangeAccess as varchar(1))+'~'+cast(USS.EditAccess as varchar(1))+'~'+cast(USS.DeleteAccess as varchar(1))
--          FROM UserPageRelation USS inner join  WebPages US on USS.WPID=US.WPID
--          WHERE USS.URID = d.URID and US.isActive=1
--          ORDER BY PageName
--          FOR XML PATH('')), 1, 1, '') [Pages]
--FROM SBP_LoginInfo a inner join UserRoleRelation b on a.Id=b.UserId inner join UserRole c on b.URRID=c.URID inner join UserPageRelation d on b.URRID=d.URID inner join WebPages e on d.WPID=e.WPID inner join Branches f on a.BranchId=f.BID
--WHERE a.isActive=1 and a.Id= @id
--GROUP BY ID,UserName,Email,c.RoleName,f.BID,f.BranchName,d.URID
--ORDER BY 1



Drop Table if exists  NostroBanks
create table NostroBanks(
ID bigint identity not null,
BankName varchar(50),
NostroLimit numeric,
NostroDescription varchar(250),
isActive bit,
CreateDate datetime,
UpdateDate datetime,
Constraint ID primary key  clustered (ID)
)

--select * from NostroBanks

-- Drop Table SBP_BlotterBreakups
--create table SBP_BlotterBreakups(
--SNo bigint identity not null,
--OpeningBalActual numeric,
--FoodPayment_inFlow numeric,
--HOKRemittance_inFlow numeric,
--ERF_inflow numeric,
--SBPChequeDeposite_inflow numeric,
--Miscellaneous_inflow numeric,
--CashWithdrawbySBPCheques_outFlow numeric,
--ERF_outflow numeric,
--DSC_outFlow numeric,
--RemitanceToHOK_outFlow numeric,
--SBPCheqGivenToOtherBank_outFlow numeric,
--Miscellaneous_outflow numeric,
--EstimatedCLossingBal numeric,
--BreakupDate DateTime,
--UserID int not null Constraint FK_SBP_BlotterBreakups_UserID Foreign key References SBP_LoginInfo(ID),
--CreateDate DATETIME,
--UpdateDate DATETIME,
--BR int,
--BID int not null Constraint FK_SBP_BlotterBreakups_BranchID Foreign key References Branches(BID),
--CurID int not null Constraint FK_SBP_BlotterBreakups_CurID Foreign key References Currencies(CID),
--Flag varchar(2),
--Constraint PK_SBP_BlotterBreakups_SNo primary key  clustered (SNo))

--truncate table SBP_BlotterBreakups
select* from SBP_BlotterBreakups

--Drop proc  SP_GetLatestBreakup
--create proc SP_GetLatestBreakup(@UserID int,@BranchID int,@CurID int,@BR int)
--as
--select a.SNo,
--a.OpeningBalActual,
--a.FoodPayment_inFlow,
--a.HOKRemittance_inFlow,
--a.ERF_inflow,
--a.SBPChequeDeposite_inflow,
--a.Miscellaneous_inflow,
--a.CashWithdrawbySBPCheques_outFlow,
--a.ERF_outflow,
--a.DSC_outFlow,
--a.RemitanceToHOK_outFlow,
--a.SBPCheqGivenToOtherBank_outFlow,
--a.Miscellaneous_outflow,
--a.EstimatedCLossingBal,a.UserID,B.BranchName,a.CurID,a.BreakupDate from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where a.UserID=@UserID and a.BID=@BranchID and a.CurID=@CurID and a.BR=@BR and cast(a.BreakupDate as date)=cast(GETDATE() as date) 


--drop proc sp_GetAllUsers
--Create proc sp_GetAllUsers
--as
--select Id,UserName,ContactNo,Email,d.RoleName,BranchName,a.isActive From [SBP_LoginInfo] a inner join Branches b on a.BranchId=b.BID inner join UserRoleRelation c on c.UserId=a.Id inner join UserRole d on d.URID=c.URID where b.isActive=1 and d.isActive=1

--drop proc sp_GetUserById
--Create proc sp_GetUserById @id int
--as
--select a.*,b.URID From [SBP_LoginInfo] a inner join UserRoleRelation b on b.UserId=a.Id where id=@id


--drop proc  SP_InsertLoginInfo
--create proc SP_InsertLoginInfo(
--	@UserName [nvarchar](50) ,
--	@Password [nvarchar](260) ,
--	@ContactNo [nvarchar](12) , 
--	@Email [nvarchar](50) , 
--	@BranchID int ,
--	@isActive bit,
--	@isConventional bit ,
--	@isislamic bit,
--	@CreateDate datetime,
--	@URID int )
--as
--begin
--insert into SBP_LoginInfo([UserName],[Password],[ContactNo],[Email],[BranchID],[isActive],[CreateDate],[isConventional],[isislamic])
--select @UserName,@Password,@ContactNo,@Email,@BranchID,@isActive,@CreateDate,@isConventional,@isislamic

--declare @ID int = SCOPE_IDENTITY();
--insert into UserRoleRelation(URID,UserId)
--select @URID,@ID 
--end


--alter table [SBP_LoginInfo]
--add DefaultPage [nvarchar](50) 

--drop proc SP_GetAllUserPageRelations
--create proc SP_GetAllUserPageRelations(@Roleid int)
--as
--select a.URID,b.UPRID,c.WPID,a.RoleName,PageName,ControllerName,DisplayName,b.DateChangeAccess,b.EditAccess,b.DeleteAccess from UserRole a inner join UserPageRelation b on a.URID=b.URID inner join WebPages c on b.WPID=c.WPID where a.isActive=1 and c.isActive=1 and a.URID=@Roleid

--drop proc SP_GetUserPageRelationById
--create proc SP_GetUserPageRelationById(@UPRID int)
--as
--select a.URID,b.UPRID,c.WPID,a.RoleName,PageName,ControllerName,DisplayName,b.DateChangeAccess,b.EditAccess,b.DeleteAccess from UserRole a inner join UserPageRelation b on a.URID=b.URID inner join WebPages c on b.WPID=c.WPID where a.isActive=1 and c.isActive=1 and b.UPRID=@UPRID



--drop proc SP_GetNotListedUserPageRelations
--create proc SP_GetNotListedUserPageRelations(@Roleid int)
--as
--select a.* From WebPages a left outer join UserPageRelation b on a.WPID=b.WPID and b.URID=@Roleid where b.UPRID is null and a.isActive=1

--create table GazettedHolidays(
--GHID int primary key identity not null,
--HolidayTitle varchar(50) not Null,
--GHDescription Varchar(250),
--GHDate DateTime not null,
--createDate DateTime,
--UpdateDate DateTime,
--UserID int not null
--)

--exec SP_AddDaysInBlotterReport '1199600000000','2021-04-02','2021-04-15',1

--drop proc SP_AddDaysInBlotterReport
alter proc SP_AddDaysInBlotterReport(@DTLValue numeric,@StartDate datetime,@EndDate datetime,@BR int)
as
begin
--declare @DTLValue numeric=1199600000000,@StartDate datetime='2021-4-2',@EndDate datetime='2021-4-15',@BR int=1;
declare @CRRID int,@CRRReq1 numeric,@CRRReq2 numeric,@Penalty numeric,@ExtBenefits numeric,@CRRCalc1 float ,@CRRCalc2 float;
select top 1 @CRRID=SNo,@Penalty=Penalty,@ExtBenefits=ExtraBenefits from SBP_BlotterCRRFINCON where BR=@BR and cast(StartDate as date)=cast(@StartDate as date) and cast(EndDate as date)=cast(@EndDate as date) order by CreateDate DESC;
select @CRRCalc1=CalcVal1/100.0,@CRRCalc2=CalcVal2/100.0 from SBP_BlotterCRRReportCalcSetup where isActive=1;
set @CRRReq1=(@DTLValue*@CRRCalc1);
set @CRRReq2=(@DTLValue*@CRRCalc2);
--DECLARE @StartDate DATE, @EndDate DATE
--SELECT @StartDate = '2021-03-01', @EndDate = '2021-03-29'; 
WITH ListDates(AllDates) AS
(    SELECT @StartDate AS DATE
    UNION ALL
    SELECT DATEADD(DAY,1,AllDates)
    FROM ListDates 
    WHERE AllDates < @EndDate)



insert into SBP_BlotterCRRReportDaysWiseBal(CRRFinconId,ReportDate,CRR3PcrReq,CRR5PcrReq,CreateDate,BR)
SELECT @CRRID,AllDates,@CRRReq1,@CRRReq2,GETDATE(),@BR FROM ListDates


update SBP_BlotterCRRFINCON set CRR1Requirement=@CRRReq1,CRR2Requirement=@CRRReq2,RequirementPenalty=(@CRRReq2+@Penalty),
RequirementExtBenefit=(@CRRReq2-@ExtBenefits),BalMaintAgainstPenalty=(cast(@CRRCalc2 as float)/cast(@CRRReq2 as float)*cast((@CRRReq2+@Penalty) as float))*100,BalMaintAgainstExtBenft=(cast(@CRRCalc2 as float)/cast(@CRRReq2 as float)*cast((@CRRReq2-@ExtBenefits) as float))*100 where SNo=@CRRID

update SBP_BlotterCRRReportDaysWiseBal set WeekDays=DATENAME(DW,CONVERT(VARCHAR(20),ReportDate,101))
end

--drop proc SP_UpdateDaysInBlotterReport
alter proc SP_UpdateDaysInBlotterReport(@DTLValue numeric,@StartDate datetime,@EndDate datetime,@BR int)
as
begin
--declare @DTLValue numeric=1199600000000,@StartDate datetime='2021-4-2',@EndDate datetime='2021-4-15',@BR int=1;
declare @CRRID int,@CRRReq1 numeric,@CRRReq2 numeric,@Penalty numeric,@ExtBenefits numeric,@CRRCalc1 float ,@CRRCalc2 float;
select top 1 @CRRID=SNo,@Penalty=Penalty,@ExtBenefits=ExtraBenefits from SBP_BlotterCRRFINCON where BR=@BR and cast(StartDate as date)=cast(@StartDate as date) and cast(EndDate as date)=cast(@EndDate as date) order by CreateDate DESC;
select @CRRCalc1=CalcVal1/100.0,@CRRCalc2=CalcVal2/100.0 from SBP_BlotterCRRReportCalcSetup where isActive=1;
set @CRRReq1=(@DTLValue*@CRRCalc1);
set @CRRReq2=(@DTLValue*@CRRCalc2);
--DECLARE @StartDate DATE, @EndDate DATE
--SELECT @StartDate = '2021-03-01', @EndDate = '2021-03-29'; 
WITH ListDates(AllDates) AS
(    SELECT @StartDate AS DATE
    UNION ALL
    SELECT DATEADD(DAY,1,AllDates)
    FROM ListDates 
    WHERE AllDates < @EndDate)


update a set a.ReportDate=b.AllDates,a.CRR3PcrReq=@CRRReq1,a.CRR5PcrReq=@CRRReq2 from (select Id,ReportDate,CRR3PcrReq,CRR5PcrReq,ROW_NUMBER() over (order by ReportDate) num from SBP_BlotterCRRReportDaysWiseBal where CRRFinconId=@CRRID) a inner join (select AllDates,ROW_NUMBER() over (order by AllDates) num from ListDates) b on a.num=b.num  

update SBP_BlotterCRRFINCON set CRR1Requirement=@CRRReq1,CRR2Requirement=@CRRReq2,RequirementPenalty=(@CRRReq2+@Penalty),
RequirementExtBenefit=(@CRRReq2-@ExtBenefits),BalMaintAgainstPenalty=cast((cast(@CRRCalc2 as float)/cast(@CRRReq2 as float)*cast((@CRRReq2+@Penalty) as float))*100 as float),BalMaintAgainstExtBenft=cast((cast(@CRRCalc2 as float)/cast(@CRRReq2 as float)*cast((@CRRReq2-@ExtBenefits) as float))*100 as float) where SNo=@CRRID

update SBP_BlotterCRRReportDaysWiseBal set WeekDays=DATENAME(DW,CONVERT(VARCHAR(20),ReportDate,101))
end


update SBP_BlotterCRRReportDaysWiseBal set BalMaintAgainstPenalty=0,BalMaintAgainstExtBenft=0

select* from SBP_BlotterCRRReportDaysWiseBal


--truncate table SBP_BlotterCRRFINCON
--truncate table SBP_BlotterCRRReportDaysWiseBal
--drop table SBP_BlotterCRRReportDaysWiseBal
CREATE TABLE [dbo].[SBP_BlotterCRRReportDaysWiseBal](
	[Id] [int] primary key IDENTITY(1,1) NOT NULL,
	CRRFinconId int not null,
	ReportDate DateTime not null,
	WeekDays varchar(20),
	KarachiTotal numeric,
	HyderabadTotal numeric,
	SukkurTotal numeric,
	LahoreTotal numeric,
	FaisalabadTotal numeric,
	GWalaTotal numeric,
	MultanTotal numeric,
	SialkotTotal numeric,
	Isalamabad numeric,
	PindiTotal numeric,
	PeshawarTotal numeric,
	BhawalpurTotal numeric,
	MuzafarbadTotal numeric,
	DIKhanTotal numeric,
	QuettaTotal numeric,
	GawadarTotal numeric,
	OtherTotal numeric,
	PakistanToTal numeric,
	CRR3PcrReq numeric,
	CRR5PcrReq numeric,
	BalMaintain3Pcr Float,
	BalMaintain5Pcr float,
	Penalty numeric,
	Remarks varchar(50),
	[BR] int,
	createDate DateTime,
	UpdateDate DateTime)


select * from SBP_BlotterCRRReportDaysWiseBal


exec [SP_SBPBlotterCRRReportGenerator] 1

alter proc [dbo].[SP_SBPBlotterCRRReportGenerator] ( @BR int)
as
begin
--declare @BR int=1
declare  @CurrentDT as datetime,@KarachiTotal numeric,
	@HyderabadTotal numeric=0,
	@SukkurTotal numeric=0,
	@LahoreTotal numeric=0,
	@FaisalabadTotal numeric=0,
	@GWalaTotal numeric=0,
	@MultanTotal numeric=0,
	@SialkotTotal numeric=0,
	@Isalamabad numeric=0,
	@PindiTotal numeric=0,
	@PeshawarTotal numeric=0,
	@BhawalpurTotal numeric=0,
	@MuzafarbadTotal numeric=0,
	@DIKhanTotal numeric=0,
	@QuettaTotal numeric=0,
	@GawadarTotal numeric=0,@PakistanTotal numeric=0, @Brr as varchar(02)='0'+cast(@BR as varchar),@CRRCalc1 float ,@CRRCalc2 float;;
--set @Br='01';
Select  @CurrentDT=cast(left(BRANPRCDATE,11) as date)  from OPICSDBLNK.OPICS43.dbo.BRPS where br=@Br ;
select @CRRCalc1=CalcVal1/100.0,@CRRCalc2=CalcVal2/100.0 from SBP_BlotterCRRReportCalcSetup where isActive=1;

select @KarachiTotal = 
SUM(case when isnull(Inflow,0.00)<0 then isnull(Inflow,0.00)*-1 else isnull(Inflow,0.00) end)  +
SUM(case when isnull(Outflow,0.00)>0 then isnull(Outflow,0.00)*-1 else isnull(Outflow,0.00) end ) + 
SUM(isnull(OpeningBalance,0.00)) 
from
(

 SELECT
  100000001 as DealNo, 
 'Opening Balance-' Description,
 '' as Status,
 '' DealDate,
 '' as ValueDate ,
 '' as MaturityDate ,
 '' Currency ,
  0.00 Inflow ,
 0.00 Outflow
 ,a.todayamount  OpeningBalance 

  FROM opicsweb.dbo.SBP_Blotteropening a
  where a.BR=@Brr and
   cast(left(a.currentdate,11) as datetime) =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
  and 
  a.sno=(select max(a.sno) from  opicsweb.dbo.SBP_Blotteropening a where BR=@Brr ) -- where  cast(left(a.currentdate,11) as datetime) =CAST(LEFT(@CurrentDT, 11) AS DATETIME))
 union all 
 SELECT
  100000002 as DealNo, 
 'Manual Balance- '+Description as Description,
 'F' as Status,
 DealDate,
 @CurrentDT as ValueDate ,
 @CurrentDT as MaturityDate ,
 'PKR' Currency ,
 sum(isnull(Inflow,0.00)) as Inflow ,
 sum(isnull(Outflow,0.00)) as Outflow,
 0 OpeningBalance
  FROM opicsweb.dbo.SBP_BlotterManualDeals a where a.BR=@Brr 
  and  cast(left(a.DealDate,11) as datetime) =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
  group by Description,DealDate
  
 union all
-- --=======================================================================================================================
-- --======================================       RTGS     =================================================================
-- --=======================================================================================================================

  SELECT   100000003 as DealNo, ACCT_Description Description  ,'M' Status	
	  ,cast(left(TXN_DTE_TME,11) as datetime) DealDate	,null ValueDate	
	  ,null MaturityDate,'PKR' Currency      ,sum(Inflow) Inflow
      ,sum(Outflow*-1) Outflow	  ,0 OpeningBalance

     
  FROM [OPICSWEB].[dbo].[SBP_BlotterRTGS]
where BatchCount=(select max(BatchCount) FROM [OPICSWEB].[dbo].[SBP_BlotterRTGS])  
and cast(left(TXN_DTE_TME,11) as datetime) =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
and BR=@Brr
group by TXN_DTE_TME,ACCT_Description



 union all
-- --=======================================================================================================================
-- --======================================       DLDT     =================================================================
-- --=======================================================================================================================

Select DEALNO, Description, Status,Deal_date as DealDate, ValueDate ,
MaturityDate,  Currency ,
case when Amount_Asset<0 then  Amount_Asset*-1 else Amount_Asset end 'Inflow',
case when Amount_Liability>0 then  Amount_Liability*-1 else Amount_Liability end 'Outflow',
0 OpeningBalance
from
(
select a.DEALNO  ,a.DealNo+'-'+rtrim(a.PRODUCT)+'-'+a.PRODTYPE+'-'+a.CNO Description,
a.DEALDATE as Deal_date,a.VDATE as ValueDate,a.MDATE as MaturityDate,a.CCY as Currency,
case when a.CCYAMT < 0 then a.CCYAMT*-1 else  a.CCYAMT end Amount_Asset ,
0 Amount_Liability,a.PORT,a.PRODUCT,'F' Status
FROM OPICSDBLNK.OPICS43.dbo.DLDT a,OPICSDBLNK.OPICS43.dbo.BRPS b,OPICSDBLNK.OPICS43.dbo.CUST d
WHERE PRODUCT IN ('PKRBR','PKUMUS','PKUMUD','PKRUWA','PKSMUS','PKSMUD','PKRSWA','USBAIM','USBAIN') AND d.CNO = a.CNO And a.REVDATE is null AND a.BR = b.BR
and a.CCY='PKR' and isnull(REVDATE,'')='' and isnull(REVREASON,'') ='' and AL='A'
and cast(left(a.VDATE,11) as datetime) =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
and  a.BR=@Brr
union all
select a.DEALNO  ,a.DealNo+'-'+rtrim(a.PRODUCT)+'-'+a.PRODTYPE+'-'+d.SN Description,CAST(LEFT(a.DEALDATE, 11) AS DATETIME) as Dealdate,
a.VDATE as ValueDate,a.MDATE as MaturityDate,
a.CCY as Currency,0 Amount_Asset,
case when a.CCYAMT > 0 then a.CCYAMT*-1 else  a.CCYAMT end Amount_Liability ,
a.PORT,a.PRODUCT ,'F' Status
FROM OPICSDBLNK.OPICS43.dbo.DLDT a inner join OPICSDBLNK.OPICS43.dbo.cust d  on d.CNO =a.CNO 
, OPICSDBLNK.OPICS43.dbo.BRPS b 
WHERE PRODUCT IN ('PKRPL','PKUMUS','PKUMUD','PKRUWA','PKSMUS','PKSMUD','PKRSWA','USBAIM','USBAIN') AND d.CNO = a.CNO
And a.REVDATE is null AND a.BR = b.BR
and a.CCY='PKR' and isnull(REVDATE,'')='' and isnull(REVREASON,'') ='' and AL='L'
and cast(left(a.VDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
and  a.BR=@Brr) a 
--==========================
union all
--============================


--Select DEALNO, Description,'' Status,Dealdate as DealDate, ValueDate as Vdate,
-- MaturityDate, Currency ,
--case when (Interest_Payments_Asset) <0 then  (Interest_Payments_Asset) *-1 else (Interest_Payments_Asset)  end 'Inflow',
--case when (Interest_Payments_Liability+PrincipalAmount)>0 then  (Interest_Payments_Liability+PrincipalAmount)*-1 else (Interest_Payments_Liability+PrincipalAmount) end 'Outflow'
--,0 OpeningBalance

Select DEALNO, Description, Status,Dealdate as DealDate, ValueDate as Vdate,
 MaturityDate, Currency ,
case when PRODUCT in ('PKRPL','PKUMUS','PKUMUD','PKRUWA','PKSMUS','PKSMUD','PKRSWA','USBAIM','USBAIN') THEN  Interest_Payments_Asset +PrincipalAmount else case when (Interest_Payments_Asset) <0 then  (Interest_Payments_Asset) *-1 else (Interest_Payments_Asset)  end end 'Inflow',
case when PRODUCT in ('PKRPL','PKUMUS','PKUMUD','PKRUWA','PKSMUS','PKSMUD','PKRSWA','USBAIM','USBAIN')  then 0 else case when (Interest_Payments_Liability+PrincipalAmount)>0 then  (Interest_Payments_Liability+PrincipalAmount)*-1 else 
(Interest_Payments_Liability+PrincipalAmount) end end 'Outflow',0 OpeningBalance

from
(
select a.DEALNO  ,a.DealNo+'-'+rtrim(a.PRODUCT)+'-'+a.PRODTYPE+'-'+d.SN Description,a.DEALDATE as Dealdate,a.VDATE as ValueDate,a.MDATE as MaturityDate,
DATEDIFF(DAY, a.VDATE, a.MDATE ) Tenor,

case when   CAST(LEFT(@CurrentDT, 11) AS DATETIME) <CAST(LEFT(a.VDATE, 11) AS DATETIME)  then 0 else 
DATEDIFF(DAY, a.vDATE, CAST(LEFT(@CurrentDT, 11) AS DATETIME)) end  AccruedDays,

a.CCY as Currency,a.CCYAMT as  PrincipalAmount,a.CCYAMT as Amount_Asset ,round(a.INTRATE,4) as Interest_rate_Asset,
(case when (a.CCY='PKR' or a.CCY='GBP') then ((a.CCYAMT*a.INTRATE)/ 36500) else ((a.CCYAMT*a.INTRATE)/ 36000) end) 
* ( CONVERT (INT, a.MDATE) - CONVERT (INT,a.VDATE) ) as Interest_Payments_Asset,
0 Amount_Liability,
0 Interest_rate_Liability ,0 Interest_Payments_Liability,
a.PORT,a.PRODUCT,'M' Status
FROM OPICSDBLNK.OPICS43.dbo.DLDT a inner join OPICSDBLNK.OPICS43.dbo.cust d  on d.CNO =a.CNO 
, OPICSDBLNK.OPICS43.dbo.BRPS b 
WHERE PRODUCT IN ('PKRBR','PKRPL','PKUMUS','PKUMUD','PKRUWA','PKSMUS','PKSMUD','PKRSWA','USBAIM','USBAIN')
 And a.REVDATE is null AND a.BR = b.BR and a.AL ='A'
and a.CCY='PKR' and isnull(REVDATE,'')='' and isnull(REVREASON,'') =''
and cast(left(a.MDATE,11) as datetime) =CAST(LEFT(@CurrentDT, 11) AS DATETIME) 
 and  a.BR=@Brr
union all


select a.DEALNO  ,a.DealNo+'-'+rtrim(a.PRODUCT)+'-'+a.PRODTYPE+'-'+d.SN  Description,a.DEALDATE as Deal_date,
a.VDATE as ValueDate,a.MDATE as MaturityDate,
DATEDIFF(DAY, a.VDATE, a.MDATE ) Tenor,
case when    CAST(LEFT(@CurrentDT, 11) AS DATETIME) <CAST(LEFT(a.VDATE, 11) AS DATETIME)   
then 0 else DATEDIFF(DAY,  a.vDATE , CAST(LEFT(@CurrentDT, 11) AS DATETIME)) end  AccruedDays,


a.CCY as Currency,a.CCYAMT as  PrincipalAmount,
0 Amount_Asset,
0 Interest_rate_Asset,
0 Interest_Payments_Asset,
a.CCYAMT as Amount_Liability,
round(a.INTRATE,4) as Interest_rate_Liability,
(case when (a.CCY='PKR' or a.CCY='GBP') then ((a.CCYAMT*a.INTRATE)/ 36500) else ((a.CCYAMT*a.INTRATE)/ 36000) end) 
* ( CONVERT (INT, a.MDATE) - CONVERT (INT,a.VDATE) ) as Interest_Payments_Liability,
a.PORT,a.PRODUCT ,'M' Status
FROM OPICSDBLNK.OPICS43.dbo.DLDT a inner join OPICSDBLNK.OPICS43.dbo.cust d  on d.CNO =a.CNO 
, OPICSDBLNK.OPICS43.dbo.BRPS b 
WHERE PRODUCT IN ('PKRBR','PKRPL','PKUMUS','PKUMUD','PKRUWA','PKSMUS','PKSMUD','PKRSWA','USBAIM','USBAIN')
And a.REVDATE is null
AND a.BR = b.BR and a.AL ='L'
and a.CCY='PKR' and isnull(a.REVDATE,'')='' and isnull(a.REVREASON,'') =''
and cast(left(a.MDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
 and  a.BR=@Brr
) a
union all
 --=======================================================================================================================
 --======================================       SPSH     =================================================================
 --=======================================================================================================================
select a.DealNo, a.DealNo+'-'+rtrim(a.PRODUCT)+'-'+a.PRODTYPE+'-'+b.SN Description,    
case when cast(left(a.SETTDATE,11) as datetime) =cast(left(@CurrentDT,11) as datetime) then 'M' else '' End Status,
a.DealDate,null Vdate,a.SETTDATE as MaturityDate, a.CCY Currency,  
case when a.PROCEEDAMT >0 then  a.PROCEEDAMT else 0 end InFlow  ,
case when a.PROCEEDAMT <0 then  a.PROCEEDAMT else 0 end OutFlow ,0 OpeningBalance
 from OPICSDBLNK.OPICS43.dbo.SPSH a
 inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CNO
where CCY='PKR' and isnull(REVDATE,'')='' and isnull(REVREASON,'') ='' and CCYSMEANS='NOS'
 and CCYSACCT in ('SBPPK','SBPIBB')
 and  br=@Brr
 and  cast(left(a.SETTDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
 union all
 ----=======================================================================================================================
 ----======================================       FXDH     =================================================================
 ----=======================================================================================================================
select a.DealNo, a.DEALNO+'-'+rtrim(a.PRODCODE)+'-'+a.PRODTYPE+'-'+b.SN Description,    
 'F' Status,
a.DealDate,a.Vdate ValueDate,null as MaturityDate , a.CCY Currency,
case when a.CCYAMT >0 then  a.CCYAMT else 0 end InFlow ,  
case when a.CCYAMT <0 then  a.CCYAMT else 0 end OutFlow
,0 OpeningBalance
from OPICSDBLNK.OPICS43.dbo.fxdh  a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CUST
where a.CCY    ='PKR' and CAST(a.CCYAMT AS numeric(38, 4)) <>0.0000 
and  br=@Brr and  isnull(REVDATE,'')='' and isnull(REVREASON,'') ='' and  CCYSMEANS='NOS'
 and a.SWAPVDATE is null
 and CCYSACCT in ('SBPPK','SBPIBB')
 and  cast(left(a.dealdate,11) as datetime)  =CAST(LEFT(a.VDATE, 11) AS DATETIME)
 and  cast(left(a.VDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
 union all
 select a.DealNo, a.DEALNO+'-'+rtrim(a.PRODCODE)+'-'+a.PRODTYPE+'-'+b.SN Description,    
 'M' Status,
a.DealDate,a.Vdate ValueDate,null as MaturityDate , a.CCY Currency,
case when a.CCYAMT >0 then  a.CCYAMT else 0 end InFlow ,  
case when a.CCYAMT <0 then  a.CCYAMT else 0 end OutFlow
,0 OpeningBalance
from OPICSDBLNK.OPICS43.dbo.fxdh  a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CUST
where a.CCY    ='PKR' and CAST(a.CCYAMT AS numeric(38, 4)) <>0.0000 
and  br=@Brr and  isnull(REVDATE,'')='' and isnull(REVREASON,'') ='' and  CCYSMEANS='NOS'
 and a.SWAPVDATE is null
 and CCYSACCT in ('SBPPK','SBPIBB')
 and  cast(left(a.dealdate,11) as datetime)  <CAST(LEFT(a.VDATE, 11) AS DATETIME)
 and  cast(left(a.VDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
union all


select a.DEALNO, a.DEALNO+'-'+ rtrim(a.PRODCODE)+'-'+a.PRODTYPE+'-'+b.SN Des,  
'F'  Status,
a.DEALDATE,a.VDATE ValueDate,Null MaturityDate ,a.CTRCCY Currency,  

 case when a.CTRAMT >0 then  a.CTRAMT else 0 end InFlow ,
 case when a.CTRAMT <0 then  a.CTRAMT else 0 end OutFlow
 ,0 OpeningBalance
 from OPICSDBLNK.OPICS43.dbo.fxdh a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CUST
 where 
 a.CTRCCY    ='PKR' and CAST(a.CTRAMT AS numeric(38, 4)) <>0.0000 
 and  br=@Brr and  isnull(REVDATE,'')='' and isnull(REVREASON,'') =''  and CTRSMEANS='NOS'

 and a.SWAPVDATE is null
 and CTRSACCT in ('SBPPK','SBPIBB')
 and  cast(left(a.dealdate,11) as datetime)  =CAST(LEFT(a.VDATE, 11) AS DATETIME)
 and  cast(left(a.VDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
 union all
 select a.DEALNO, a.DEALNO+'-'+ rtrim(a.PRODCODE)+'-'+a.PRODTYPE+'-'+b.SN Des,  
'M'  Status,
a.DEALDATE,a.VDATE ValueDate,Null MaturityDate ,a.CTRCCY Currency,  

 case when a.CTRAMT >0 then  a.CTRAMT else 0 end InFlow ,
 case when a.CTRAMT <0 then  a.CTRAMT else 0 end OutFlow
 ,0 OpeningBalance
 from OPICSDBLNK.OPICS43.dbo.fxdh a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CUST
 where a.CTRCCY    ='PKR' and CAST(a.CTRAMT AS numeric(38, 4)) <>0.0000 
 and  br=@Brr and  isnull(REVDATE,'')='' and isnull(REVREASON,'') =''  and CTRSMEANS='NOS'

 and a.SWAPVDATE is null
 and CTRSACCT in ('SBPPK','SBPIBB')
 and  cast(left(a.dealdate,11) as datetime)  <CAST(LEFT(a.VDATE, 11) AS DATETIME)
 and  cast(left(a.VDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
  
  
---- =======================================================================================================================
-- --======================================       FXDH   End================================================================
-- --=======================================================================================================================  
  union all
-- --=======================================================================================================================
-- --======================================       FXDH SWAP     ============================================================
-- --=======================================================================================================================

select a.DealNo, a.DEALNO+'-'+rtrim(a.PRODCODE)+'-'+a.PRODTYPE+'-'+b.SN Description,    
'F' Status,
a.DealDate,a.Vdate,a.SWAPVDATE as MaturityDate , a.CCY Currency,  
 case when a.CCYAMT >0 then  a.CCYAMT else 0 end InFlow, 
case when a.CCYAMT <0 then  a.CCYAMT else 0 end ,0 OpeningBalance
from OPICSDBLNK.OPICS43.dbo.fxdh  a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CUST
where a.CCY    ='PKR' and CAST(a.CCYAMT AS numeric(38, 4)) <>0.0000 
and  br=@Brr and  isnull(REVDATE,'')='' and isnull(REVREASON,'') ='' and  CCYSMEANS='NOS'
and CCYSACCT in ('SBPPK','SBPIBB')
and  CAST(LEFT(@CurrentDT, 11) AS DATETIME)<cast(left(a.SWAPVDATE,11) as datetime) 
and  cast(left(a.dealdate,11) as datetime)  <=CAST(LEFT(a.VDATE, 11) AS DATETIME)
and  cast(left(a.VDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
union all

select a.DealNo, a.DEALNO+'-'+rtrim(a.PRODCODE)+'-'+a.PRODTYPE+'-'+b.SN Description,    
'M' Status,
a.DealDate,a.Vdate,a.SWAPVDATE as MaturityDate , a.CCY Currency,  
 case when a.CCYAMT >0 then  a.CCYAMT else 0 end InFlow, 
case when a.CCYAMT <0 then  a.CCYAMT else 0 end OutFlow,0 OpeningBalance
from OPICSDBLNK.OPICS43.dbo.fxdh  a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CUST
where a.CCY    ='PKR' and CAST(a.CCYAMT AS numeric(38, 4)) <>0.0000 
and  br=@Brr and  isnull(REVDATE,'')='' and isnull(REVREASON,'') ='' and  CCYSMEANS='NOS'
and CCYSACCT in ('SBPPK','SBPIBB')
and  cast(left(a.VDATE,11) as datetime)     =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
and  cast(left(@CurrentDT,11) as datetime)  >cast(left(a.SWAPVDATE,11) as datetime) 
and  CAST(LEFT(@CurrentDT, 11) AS DATETIME) >cast(left(a.dealdate,11) as datetime)
union all
--===================================================================================


select a.DEALNO, a.DEALNO+'-'+ rtrim(a.PRODCODE)+'-'+a.PRODTYPE+'-'+b.SN Des,  
'F'  Status,
a.DEALDATE,a.VDATE ValueDate,Null MaturityDate ,a.CTRCCY Currency,  

 case when a.CTRAMT >0 then  a.CTRAMT else 0 end InFlow ,
 case when a.CTRAMT <0 then  a.CTRAMT else 0 end OutFlow,0 OpeningBalance
 from OPICSDBLNK.OPICS43.dbo.fxdh a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CUST
 where 
 a.CTRCCY    ='PKR' and CAST(a.CTRAMT AS numeric(38, 4)) <>0.0000 
 and  br=@Brr and  isnull(REVDATE,'')='' and isnull(REVREASON,'') =''  and CTRSMEANS='NOS'

 and a.SWAPVDATE is not null
 and CTRSACCT in ('SBPPK','SBPIBB')
and  CAST(LEFT(@CurrentDT, 11) AS DATETIME)<cast(left(a.SWAPVDATE,11) as datetime) 
and  cast(left(a.dealdate,11) as datetime) <=CAST(LEFT(a.VDATE, 11) AS DATETIME)
and  cast(left(a.VDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
 union all
 select a.DEALNO, a.DEALNO+'-'+ rtrim(a.PRODCODE)+'-'+a.PRODTYPE+'-'+b.SN Description,  
'M'  Status,
a.DEALDATE,a.VDATE ValueDate,Null MaturityDate ,a.CTRCCY Currency,  

 case when a.CTRAMT >0 then  a.CTRAMT else 0 end InFlow ,
 case when a.CTRAMT <0 then  a.CTRAMT else 0 end OutFlow,0 OpeningBalance
 from OPICSDBLNK.OPICS43.dbo.fxdh a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CUST
 where a.CTRCCY    ='PKR' and CAST(a.CTRAMT AS numeric(38, 4)) <>0.0000 
 and  br=@Brr and  isnull(REVDATE,'')='' and isnull(REVREASON,'') =''  and CTRSMEANS='NOS'
  and a.SWAPVDATE is not null
 and CTRSACCT in ('SBPPK','SBPIBB')
and  cast(left(a.VDATE,11) as datetime)     =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
and  cast(left(@CurrentDT,11) as datetime)  >cast(left(a.SWAPVDATE,11) as datetime) 
and  CAST(LEFT(@CurrentDT, 11) AS DATETIME) >cast(left(a.dealdate,11) as datetime)





 UNION all
--  --=======================================================================================================================
-- --======================================       RPRH          ============================================================
-- --=======================================================================================================================
 select a.DEALNO,
a.DealNo+'-'+rtrim(a.PRODUCT)+'-'+a.PRODTYPE+'-'+b.SN 
 Description,
'F' Status,
a.DEALDATE as Deal_date,
a.VDATE as ValueDate,
a.MATDATE as MaturityDate,
a.CCY as Currency,
0 'InFlow',
a.COMPROCDAMT 'OutFlow',
0 OpeningBalance
from OPICSDBLNK.OPICS43.dbo.RPRH a inner join OPICSDBLNK.OPICS43.dbo.cust b on b.CNO =a.CNO
 where a.CCY    ='PKR' and CAST(a.COMPROCDAMT AS numeric(38, 4)) <>0.0000  and a.PRODTYPE='RB'
 and  br=@Brr  and  isnull(REVDATE,'')='' and isnull(REVREASON,'') =''  and a.COMCCYSMEANS='NOS'
 and a.COMCCYSACCT in ('SBPPK','SBPIBB')  and  cast(left(a.VDATE,11) as datetime)=CAST(LEFT(@CurrentDT, 11) AS DATETIME)
 
 union all

 select a.DEALNO,
a.DealNo+'-'+rtrim(a.PRODUCT)+'-'+a.PRODTYPE+'-'+b.SN  Description,'M' Status,
a.DEALDATE as Deal_date,a.VDATE as ValueDate,a.MATDATE as MaturityDate,a.CCY as Currency,a.MATPROCDAMT 'InFlow',0 'OutFlow',
0 OpeningBalance
 from OPICSDBLNK.OPICS43.dbo.RPRH a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CNO
 where a.CCY    ='PKR' and CAST(a.MATPROCDAMT AS numeric(38, 4)) <>0.0000  and a.PRODTYPE='RB'
 and  br=@Brr  and  isnull(REVDATE,'')='' and isnull(REVREASON,'') =''  and a.MATCCYSMEANS='NOS'
 and a.MATCCYSACCT in ('SBPPK','SBPIBB')
 and  cast(left(a.MATDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
 union all

 select 
a.DEALNO,
a.DealNo+'-'+rtrim(a.PRODUCT)+'-'+a.PRODTYPE+'-'+b.sn as Description,
'F' as Status,
a.DEALDATE as Deal_date,
a.VDATE as ValueDate,
a.MATDATE as MaturityDate,
a.CCY as Currency,
a.COMPROCDAMT as 'InFlow',
0 as 'OutFlow',
0 as OpeningBalance 
 from OPICSDBLNK.OPICS43.dbo.RPRH a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CNO
 where a.CCY    ='PKR' and CAST(a.COMPROCDAMT AS numeric(38, 4)) <>0.0000  and a.PRODTYPE='RS'
 and  br=@Brr  and  isnull(REVDATE,'')='' and isnull(REVREASON,'') =''  and a.COMCCYSMEANS='NOS'
 and a.COMCCYSACCT in ('SBPPK','SBPIBB')  and  cast(left(a.VDATE,11) as datetime)=CAST(LEFT(@CurrentDT, 11) AS DATETIME)
 union all

 select a.DEALNO,
a.DealNo+'-'+rtrim(a.PRODUCT)+'-'+a.PRODTYPE+'-'+b.sn Description,'M' Status,
a.DEALDATE as Deal_date,a.VDATE as ValueDate,a.MATDATE as MaturityDate,a.CCY as Currency,0 'InFlow',a.MATPROCDAMT 'OutFlow',
0 OpeningBalance
 from OPICSDBLNK.OPICS43.dbo.RPRH a inner join OPICSDBLNK.OPICS43.dbo.cust b  on b.CNO =a.CNO
 where a.CCY    ='PKR' and CAST(a.MATPROCDAMT AS numeric(38, 4)) <>0.0000  and a.PRODTYPE='RS'
 and  br=@Brr  and  isnull(REVDATE,'')='' and isnull(REVREASON,'') =''  and a.MATCCYSMEANS='NOS'
 and a.MATCCYSACCT in ('SBPPK','SBPIBB')
 and  cast(left(a.MATDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
------ --=======================================================================================================================
------ --======================================       TPOS          ============================================================
------ --=======================================================================================================================
  union all
 Select 0 DealNo,a.secid+'-' +(CONVERT(Varchar(12),b.MDATE)) Description, 'M' Status,null  as DealDate,null ValueDate ,
b.mdate MaturityDate,a.ccy  Currency ,case when a.prinamt< 0 then  a.prinamt*-1 else  a.prinamt end 'InFlow',0 'Outflow'
, 0.00 OpeningBalance from OPICSDBLNK.OPICS43.dbo.tpos a
inner join OPICSDBLNK.OPICS43.dbo.secm b on a.PRODUCT =b.PRODUCT AND b.SECID = a.SECID
inner join OPICSDBLNK.OPICS43.dbo.BRPS c on c.BR = a.BR
where a.PRINAMT <>'0'
and a.product in ('tbill','bond','SUKUK')
--AND TPOS.PRODTYPE = SECM.PRODTYPE
and cast(left(b.mDATE,11) as datetime)  =CAST(LEFT(@CurrentDT, 11) AS DATETIME)
AND a.BR =@Brr 
and mktval <> '0'
union all
----=======================================================================================================================
-- --======================================  BOND, SUKUK,PIB   ============================================================
-- --=======================================================================================================================


select 
0 DealNo, ltrim(rtrim(ACCOUNTNO))+'-'+ltrim(rtrim(ACCTTITLE))+'--'+SECID Description,
'M' Status, 
null  DealDate ,
null  ValueDate, 
MDATE MaturityDate,
'PKR' Currency,
case when sum(PRINCIPAL)<0 then sum(PRINCIPAL) *-1 else  sum(PRINCIPAL) end InFlow, 
0 OutFlow,0 OpeningBalance
from(
SELECT a.ACCOUNTNO,b.ACCTTITLE,a.SECID,c.MDATE,
       ((a.PURCHQTY-a.SALEQTY)) PRINCIPAL
FROM OPICSDBLNK.OPICS43.dbo.SACH  a inner join OPICSDBLNK.OPICS43.dbo.SACC b
on a.ACCOUNTNO = b.ACCOUNTNO AND a.BR = b.BR
inner join OPICSDBLNK.OPICS43.dbo.SECM c on c.SECID = a.SECID and c.ccy='PKR'
WHERE 
 cast(left(c.MDATE,11) as datetime)  =  cast(left(@CurrentDT,11) as datetime)
AND a.PURCHQTY-a.SALEQTY <> 0
and a.br=@Brr
UNION all 
SELECT '1','HBL BANK HOLDINGS',a.SECID,c.MDATE,
a.SETTQTY PRINCIPAL
FROM 
OPICSDBLNK.OPICS43.dbo.TPOS a inner join 
OPICSDBLNK.OPICS43.dbo.SECM c on  c.SECID = a.SECID and  c.ccy=a.ccy and a.ccy='PKR'
AND a.SETTQTY <> 0 and a.ccy='PKR'
where  cast(left(c.MDATE,11) as datetime)  =   cast(left(@CurrentDT,11) as datetime)) a
group by ACCOUNTNO,ACCTTITLE,SECID,MDATE

union all
SELECT 
0 DealNo ,
ltrim(rtrim(a.ACCOUNTNO))+'-'+ltrim(rtrim(c.ACCTTITLE))+'--'+a.SECID Description,
'M' Status ,
 null DealDate,                
 null ValueDate,              
 b.INTENDDTE MaturityDate,
 'PKR' Currency,
((a.PURCHQTY-a.SALEQTY)*b.INTPAYAMT_8)  Inflow,
 0 OutFlow
 ,0 OpeningBalance
FROM 
OPICSDBLNK.OPICS43.dbo.SACH a 
inner join OPICSDBLNK.OPICS43.dbo.SECS b on  b.SECID = a.SECID 
inner join OPICSDBLNK.OPICS43.dbo.SACC c on a.ACCOUNTNO = c.ACCOUNTNO
AND a.BR = c.BR and a.br=@Brr --and c.ccy='PKR'
WHERE 
 cast(left(b.INTENDDTE,11) as datetime) =   cast(left(@CurrentDT,11) as datetime)
and  a.PURCHQTY-a.SALEQTY <> 0
) a
Select  @CurrentDT=cast(GETDATE() as date)



select @KarachiTotal=(@KarachiTotal+isnull(a.EstimatedCLossingBal,0)) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Karachi%'
select @HyderabadTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Hyderabad%'
select @SukkurTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Sukkur%'
select @LahoreTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Lahore%'
select @FaisalabadTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Faisalabad%'
select @GWalaTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Gujranwala%'
select @MultanTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Multan%'
select @SialkotTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Sialkot%'
select @Isalamabad=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Islamabad%'
select @PindiTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%RawalPindi%'
select @PeshawarTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Peshawar%'
select @BhawalpurTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Bhawalpur%'
select @MuzafarbadTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Muzafarabad%'
select @DIKhanTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%DIKhan%'
select @GawadarTotal=isnull(a.EstimatedCLossingBal,0) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Gawadar%'


set @PakistanTotal=(@KarachiTotal+@HyderabadTotal+@SukkurTotal+@LahoreTotal+@FaisalabadTotal+@GWalaTotal+@MultanTotal+@SialkotTotal+@Isalamabad+@PindiTotal+@PeshawarTotal+@BhawalpurTotal+@MuzafarbadTotal+@DIKhanTotal+@GawadarTotal);

update SBP_BlotterCRRReportDaysWiseBal set KarachiTotal = @KarachiTotal,HyderabadTotal=@HyderabadTotal,SukkurTotal=@SukkurTotal,LahoreTotal=@LahoreTotal,FaisalabadTotal=@FaisalabadTotal,GWalaTotal=@GWalaTotal,
MultanTotal=@MultanTotal,SialkotTotal=@SialkotTotal,Isalamabad=@Isalamabad,PindiTotal=@PindiTotal,PeshawarTotal=@PeshawarTotal,BhawalpurTotal=@BhawalpurTotal,MuzafarbadTotal=@MuzafarbadTotal,
DIKhanTotal=@DIKhanTotal,GawadarTotal=@GawadarTotal,PakistanTotal=@PakistanTotal,BalMaintain3Pcr=(@CRRCalc1/CRR3PcrReq*@PakistanTotal),BalMaintain5Pcr=(@CRRCalc2/CRR5PcrReq*@PakistanTotal) where BR=@BR and cast(ReportDate as date)=@CurrentDT 

end



alter proc SP_GETLatestBlotterDTLReportDayWise(@BR int)
as
select Id,
CRRFinconId,
cast(ReportDate as date)ReportDate,
WeekDays,
isnull(KarachiTotal,0)KarachiTotal,
isnull(HyderabadTotal,0) HyderabadTotal,
isnull(SukkurTotal,0)SukkurTotal,
isnull(LahoreTotal,0)LahoreTotal,
isnull(FaisalabadTotal,0)FaisalabadTotal,
isnull(GWalaTotal,0)GWalaTotal,
isnull(MultanTotal,0)MultanTotal,
isnull(SialkotTotal,0)SialkotTotal,
isnull(Isalamabad,0)Isalamabad,
isnull(PindiTotal,0)PindiTotal,
isnull(PeshawarTotal,0)PeshawarTotal,
isnull(BhawalpurTotal,0)BhawalpurTotal,
isnull(MuzafarbadTotal,0)MuzafarbadTotal,
isnull(DIKhanTotal,0)DIKhanTotal,
isnull(QuettaTotal,0)QuettaTotal,
isnull(GawadarTotal,0)GawadarTotal,
isnull(OtherTotal,0)OtherTotal,
isnull(PakistanToTal,0)PakistanToTal,
isnull(CRR3PcrReq,0)CRR3PcrReq,
isnull(CRR5PcrReq,0)CRR5PcrReq,
isnull(BalMaintain3Pcr,0)BalMaintain3Pcr,
isnull(BalMaintain5Pcr,0)BalMaintain5Pcr,
isnull(Penalty,0)Penalty,
Remarks,
BR,
createDate,
UpdateDate From SBP_BlotterCRRReportDaysWiseBal where CRRFinconId=(select top 1 SNo from SBP_BlotterCRRFINCON order by SNo DESC)



--drop table SBP_BlotterCRRReportCalcSetup
create table SBP_BlotterCRRReportCalcSetup(
ID int primary key identity not null,
CalcVal1 float,
CalcVal2 float,
isActive bit,
CreatedDate datetime,
UpdateDate datetime,
UserID int not null Constraint FK_SBP_BlotterCRRReportCalcSetup_UserID Foreign key References SBP_LoginInfo(ID),
)

--insert into SBP_BlotterCRRReportCalcSetup(CalcVal1,CalcVal2,isActive,CreatedDate,UserID) values(3,5,1,GETDATE(),10)