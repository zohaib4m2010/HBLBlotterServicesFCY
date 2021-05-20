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


--alter table SBP_LoginInfo
--add BlotterType varchar(3)

--alter table SBP_LoginInfo
--add isLoggedIn bit

--update SBP_LoginInfo set BlotterType='LCY'

--update [SBP_LoginInfo] set isConventional=1,isislamic=0


select* From [SBP_LoginInfo] where UserName='Wasim' and Password='WkAhCV0uZrLilmxNYOHHPA==' and isActive=1



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


--insert into Branches(BranchCode,BranchName) values('1002','Hyderabad')

--insert into Branches(BranchCode,BranchName) values('1003','Sukkur')

--insert into Branches(BranchCode,BranchName) values('1004','Lahore')

--insert into Branches(BranchCode,BranchName) values('1005','Faisalabad')

--insert into Branches(BranchCode,BranchName) values('1006','Gujranwala')

--insert into Branches(BranchCode,BranchName) values('1007','Multan')

--insert into Branches(BranchCode,BranchName) values('1008','Sialkot')

--insert into Branches(BranchCode,BranchName) values('1009','Islamabad')

--insert into Branches(BranchCode,BranchName) values('1010','RawalPindi')

--insert into Branches(BranchCode,BranchName) values('1011','Peshawar')

--insert into Branches(BranchCode,BranchName) values('1012','Bahawalpur')

--insert into Branches(BranchCode,BranchName) values('1013','Muzafarabad')

--insert into Branches(BranchCode,BranchName) values('1014','DIKhan')

--insert into Branches(BranchCode,BranchName) values('1015','Quetta')


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
select * from UserRole

--Drop Table if exists  UserRoleRelation;
create table UserRoleRelation
(
URRID int primary key identity not null,
UserId int not null Constraint FK_URRUserID Foreign key References SBP_LoginInfo(ID),
URID int not null COnstraint FK_URURID Foreign key References UserRole(URID),
)

select * from UserRoleRelation

--update UserRoleRelation set URID=3 where URRID > 1


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

-- truncate table SBP_BlotterTransactionTitles
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



--update SBP_BlotterTransactionTitles set TranctionTitle='Normal Clearing' where TTID=6
--update SBP_BlotterTransactionTitles set TranctionTitle='SameDay Clearing' where TTID=7
--update SBP_BlotterTransactionTitles set TranctionTitle='Special Clearing' where TTID=8
--update SBP_BlotterTransactionTitles set TranctionTitle='Intercity Clearing' where TTID=9
--update SBP_BlotterTransactionTitles set TranctionTitle='Inter-Switch/One-link' where TTID=10
--update SBP_BlotterTransactionTitles set TranctionTitle='CDNS - Normal' where TTID=11
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Normal Clearing','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('SameDay Clearing','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Special Clearing','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Intercity Clearing','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Inter-Switch/One-link','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('CDNS - Normal','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('CDNS - Same Day','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Clearing Return','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Special Returns','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Intercity Returns','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Sameday Returns','Clearing',1,GETDATE())
--insert into SBP_BlotterTransactionTitles(TranctionTitle,Transactionfor,isActive,CreateDate) values('Special Returns','Clearing',1,GETDATE())



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
AdjTBO_InFlow numeric,
TBO_OutFLow numeric,
AdjTBO_OutFLow numeric,
Note nvarchar(250),
UserID int not null Constraint FK_SBP_BlotterTBO_UserID Foreign key References SBP_LoginInfo(ID),
CreateDate DATETIME,
UpdateDate DATETIME,
BR int not null,
BID int not null Constraint FK_SBP_BlotterTBO_BranchID Foreign key References Branches(BID),
CurID int not null Constraint FK_SBP_BlotterTBO_CurID Foreign key References Currencies(CID),
Flag varchar(2),
Constraint PKTBO_SNo primary key  clustered (Sno))

--truncate table SBP_BlotterTBO 

select* from SBP_BlotterTBO


--drop proc SP_GetAll_SBPBlotterTBO
Create proc SP_GetAll_SBPBlotterTBO(@UserID int,@BranchID int,@CurID int,@BR int)
as
Begin
select TBO.SNo,TBO.TTID,TT.TranctionTitle TransactionType,TBO.TBO_Date,TBOCOde,isnull(TBO.AdjTBO_InFlow,TBO.TBO_InFlow) TBO_InFlow,isnull(AdjTBO_OutFLow, TBO.TBO_OutFLow)TBO_OutFLow,TBO.Note,TBO.CreateDate,TBO.UpdateDate,TBO.BR,TBO.CurID,TBO.Flag 
From SBP_BlotterTBO TBO inner join SBP_BlotterTransactionTitles TT on TBO.TTID=TT.TTID
where TBO.UserID=@UserID and TBO.BR=@BR and BID=@BranchID and TBO.CurID=@CurID
end


--Drop proc if exists SP_GETAllTBOTransactionTitles
create proc SP_GETAllTBOTransactionTitles
as
Begin

select TTID,TranctionTitle From SBP_BlotterTransactionTitles where Transactionfor='TBO' and  isActive=1

End




--truncate table SBP_BlotterClearing
--Drop Table  SBP_BlotterClearing;
create table SBP_BlotterClearing
(
SNo bigint identity not null,
TTID int not null Constraint FK_SBP_BlotterClearing_TID Foreign key References SBP_BlotterTransactionTitles(TTID),
Clearing_Date DATETIME,
ClearingCOde nvarchar(20),
Clearing_InFlow numeric,
AdjClearing_InFlow numeric,
Clearing_OutFLow numeric,
AdjClearing_OutFLow numeric,
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
select Clearing.SNo,Clearing.TTID,TT.TranctionTitle TransactionType,Clearing.Clearing_Date,ClearingCOde,isnull(Clearing.AdjClearing_InFlow,Clearing.Clearing_InFlow)Clearing_InFlow,isnull(Clearing.AdjClearing_OutFLow,Clearing.Clearing_OutFLow)Clearing_OutFLow,Clearing.Note,Clearing.CreateDate,Clearing.UpdateDate,Clearing.BR,Clearing.BID,Clearing.CurID,Clearing.Flag 
From SBP_BlotterClearing Clearing inner join SBP_BlotterTransactionTitles TT on Clearing.TTID=TT.TTID
where Clearing.UserID=@UserID and Clearing.BID=@BranchID and Clearing.CurID=@CurID and BR=@BR
end

--Drop proc if exists SP_GETAllClearingTransactionTitles
create proc SP_GETAllClearingTransactionTitles
as
Begin

select TTID,TranctionTitle From SBP_BlotterTransactionTitles where Transactionfor='Clearing' and  isActive=1

End

--truncate table SBP_BlotterTrade
--Drop Table if exists  SBP_BlotterTrade;
create table SBP_BlotterTrade
(
SNo bigint identity not null,
TTID int not null Constraint FK_SBP_BlotterTrade_TID Foreign key References SBP_BlotterTransactionTitles(TTID),
Trade_Date DATETIME,
TradeCOde nvarchar(20),
Trade_InFlow numeric,
AdjTrade_InFlow numeric,
Trade_OutFLow numeric,
AdjTrade_OutFLow numeric,
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
select Trade.SNo,Trade.TTID,TT.TranctionTitle TransactionType,Trade.Trade_Date,Trade.TradeCOde,isnull(Trade.AdjTrade_InFlow,Trade.Trade_InFlow)Trade_InFlow,isnull(Trade.AdjTrade_OutFLow,Trade.Trade_OutFLow)Trade_OutFLow,Trade.Note,Trade.CreateDate,Trade.UpdateDate,Trade.BR,Trade.BID,Trade.CurID,Trade.Flag 
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
alter Proc SP_GetSBPBlotterCRRFINCON(@UserID int,@BranchID int ,@CurID int,@BR int)
as
select * from SBP_BlotterCRRFINCON --where cast(StartDate as date) <= cast(GETDATE() as date) and cast(EndDate as date) >= cast(GETDATE() as date) and UserID=@UserID and BID=@BranchID and CurID=@CurID and BR=@BR 



--truncate table SBP_BlotterCRRFINCON

--Drop proc if exists SP_SBPGetLoginInfoById
--create proc SP_SBPGetLoginInfoById(@id int)
--as
--		SELECT 
--   ID,UserName,Email,c.RoleName,f.BID BranchID,f.BranchName,'Success' AS UserExists 
--   STUFF((SELECT ', ' + US.DisplayName +'~' + US.PageName  + '~'+US.ControllerName+'~'+cast(USS.DateChangeAccess as varchar(1))+'~'+cast(USS.EditAccess as varchar(1))+'~'+cast(USS.DeleteAccess as varchar(1))
--          FROM UserPageRelation USS inner join  WebPages US on USS.WPID=US.WPID
--          WHERE USS.URID = d.URID and US.isActive=1
--          ORDER BY PageName
--          FOR XML PATH('')), 1, 1, '') [Pages]
--FROM SBP_LoginInfo a inner join UserRoleRelation b on a.Id=b.UserId inner join UserRole c on b.URID=c.URID inner join UserPageRelation d on b.URID=d.URID inner join WebPages e on d.WPID=e.WPID inner join Branches f on a.BranchId=f.BID
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
create table SBP_BlotterBreakups(
SNo bigint identity not null,
OpeningBalActual numeric,
AdjOpeningBalActual numeric,
FoodPayment_inFlow numeric,
AdjFoodPayment_inFlow numeric,
HOKRemittance_inFlow numeric,
AdjHOKRemittance_inFlow numeric,
ERF_inflow numeric,
AdjERF_inflow numeric,
SBPChequeDeposite_inflow numeric,
AdjSBPChequeDeposite_inflow numeric,
Miscellaneous_inflow numeric,
AdjMiscellaneous_inflow numeric,
CashWithdrawbySBPCheques_outFlow numeric,
AdjCashWithdrawbySBPCheques_outFlow numeric,
ERF_outflow numeric,
AdjERF_outflow numeric,
DSC_outFlow numeric,
AdjDSC_outFlow numeric,
RemitanceToHOK_outFlow numeric,
AdjRemitanceToHOK_outFlow numeric,
SBPCheqGivenToOtherBank_outFlow numeric,
AdjSBPCheqGivenToOtherBank_outFlow numeric,
Miscellaneous_outflow numeric,
AdjMiscellaneous_outflow numeric,
EstimatedCLossingBal numeric,
AdjEstimatedCLossingBal numeric,
BreakupDate DateTime,
AdjDate DateTime,
UserID int not null Constraint FK_SBP_BlotterBreakups_UserID Foreign key References SBP_LoginInfo(ID),
CreateDate DATETIME,
UpdateDate DATETIME,
BR int,
BID int not null Constraint FK_SBP_BlotterBreakups_BranchID Foreign key References Branches(BID),
CurID int not null Constraint FK_SBP_BlotterBreakups_CurID Foreign key References Currencies(CID),
Flag varchar(2),
Constraint PK_SBP_BlotterBreakups_SNo primary key  clustered (SNo))

--truncate table SBP_BlotterBreakups
select* from SBP_BlotterBreakups

delete from SBP_BlotterBreakups where SNo = 3

--Drop proc  SP_GetLatestBreakup
alter proc SP_GetLatestBreakup(@UserID int,@BranchID int,@CurID int,@BR int)
as
select a.SNo,
isnull(a.AdjOpeningBalActual,a.OpeningBalActual)OpeningBalActual,
isnull(a.AdjFoodPayment_inFlow,a.FoodPayment_inFlow)FoodPayment_inFlow,
isnull(a.AdjHOKRemittance_inFlow,a.HOKRemittance_inFlow)HOKRemittance_inFlow,
isnull(a.AdjERF_inflow,ERF_inflow)ERF_inflow,
isnull(a.AdjSBPChequeDeposite_inflow,a.SBPChequeDeposite_inflow)SBPChequeDeposite_inflow,
isnull(a.AdjMiscellaneous_inflow,a.Miscellaneous_inflow)Miscellaneous_inflow,
isnull(a.AdjCashWithdrawbySBPCheques_outFlow,a.CashWithdrawbySBPCheques_outFlow)CashWithdrawbySBPCheques_outFlow,
isnull(a.AdjERF_outflow,a.ERF_outflow)ERF_outflow,
isnull(a.AdjDSC_outFlow,a.DSC_outFlow)DSC_outFlow,
isnull(a.AdjRemitanceToHOK_outFlow,a.RemitanceToHOK_outFlow)RemitanceToHOK_outFlow,
isnull(a.AdjSBPCheqGivenToOtherBank_outFlow,a.SBPCheqGivenToOtherBank_outFlow)SBPCheqGivenToOtherBank_outFlow,
isnull(a.AdjMiscellaneous_outflow,a.Miscellaneous_outflow)Miscellaneous_outflow,
isnull(a.AdjEstimatedCLossingBal,a.EstimatedCLossingBal)EstimatedCLossingBal,
a.UserID,B.BranchName,a.CurID,a.BreakupDate from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID 
where a.BID=@BranchID and a.CurID=@CurID and a.BR=@BR and cast(a.BreakupDate as date)=cast(GETDATE() as date)  --and a.UserID=@UserID


--drop proc sp_GetAllUsers
--Create proc sp_GetAllUsers
--as
--select Id,UserName,ContactNo,Email,d.RoleName,BranchName,a.BlotterType,a.isActive From [SBP_LoginInfo] a inner join Branches b on a.BranchId=b.BID inner join UserRoleRelation c on c.UserId=a.Id inner join UserRole d on d.URID=c.URID where b.isActive=1 and d.isActive=1

--drop proc sp_GetUserById
--Create proc sp_GetUserById @id int
--as
--select a.*,b.URID From [SBP_LoginInfo] a inner join UserRoleRelation b on b.UserId=a.Id where id=@id


drop proc  SP_InsertLoginInfo
alter proc SP_InsertLoginInfo(
	@UserName [nvarchar](50) ,
	@Password [nvarchar](260) ,
	@ContactNo [nvarchar](12) , 
	@Email [nvarchar](50) , 
	@BranchID int ,
	@isActive bit,
	@isConventional bit ,
	@isislamic bit,
	@CreateDate datetime, 
	@BlotterType [nvarchar](50) , 
	@URID int )
as
begin
Declare @CurrencyID int;
insert into SBP_LoginInfo([UserName],[Password],[ContactNo],[Email],[BranchID],[isActive],[CreateDate],[isConventional],[isislamic],BlotterType)
select @UserName,@Password,@ContactNo,@Email,@BranchID,@isActive,@CreateDate,@isConventional,@isislamic,@BlotterType

declare @ID int = SCOPE_IDENTITY();
insert into UserRoleRelation(URID,UserId)
select @URID,@ID 

end


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
--declare @BR int=1;
declare  @CurrentDT as datetime,@KarachiTotal numeric=0,
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

Select  @CurrentDT=cast(GETDATE() as date)
select @KarachiTotal = ClosingBal from SBP_BlotterTransactionsTotal where cast(DateFor as date)=@CurrentDT


select @KarachiTotal=(@KarachiTotal+isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal)) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Karachi%'
select @HyderabadTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Hyderabad%'
select @SukkurTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Sukkur%'
select @LahoreTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Lahore%'
select @FaisalabadTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Faisalabad%'
select @GWalaTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Gujranwala%'
select @MultanTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Multan%'
select @SialkotTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Sialkot%'
select @Isalamabad=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Islamabad%'
select @PindiTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%RawalPindi%'
select @PeshawarTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Peshawar%'
select @BhawalpurTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Bhawalpur%'
select @MuzafarbadTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Muzafarabad%'
select @DIKhanTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%DIKhan%'
select @GawadarTotal=isnull(a.EstimatedCLossingBal,a.AdjEstimatedCLossingBal) from SBP_BlotterBreakups a inner join Branches b on a.BID=b.BID where BR=@BR and cast(BreakupDate as date)=@CurrentDT and b.BranchName like '%Gawadar%'


set @PakistanTotal=(@KarachiTotal+@HyderabadTotal+@SukkurTotal+@LahoreTotal+@FaisalabadTotal+@GWalaTotal+@MultanTotal+@SialkotTotal+@Isalamabad+@PindiTotal+@PeshawarTotal+@BhawalpurTotal+@MuzafarbadTotal+@DIKhanTotal+@GawadarTotal);

update SBP_BlotterCRRReportDaysWiseBal set KarachiTotal = @KarachiTotal,HyderabadTotal=@HyderabadTotal,SukkurTotal=@SukkurTotal,LahoreTotal=@LahoreTotal,FaisalabadTotal=@FaisalabadTotal,GWalaTotal=@GWalaTotal,
MultanTotal=@MultanTotal,SialkotTotal=@SialkotTotal,Isalamabad=@Isalamabad,PindiTotal=@PindiTotal,PeshawarTotal=@PeshawarTotal,BhawalpurTotal=@BhawalpurTotal,MuzafarbadTotal=@MuzafarbadTotal,
DIKhanTotal=@DIKhanTotal,GawadarTotal=@GawadarTotal,PakistanTotal=@PakistanTotal,BalMaintain3Pcr=(@CRRCalc1/CRR3PcrReq*@PakistanTotal),BalMaintain5Pcr=(@CRRCalc2/CRR5PcrReq*@PakistanTotal),Remarks=case when (@PakistanTotal-CRR3PcrReq) <=0 then 'Warning' else 'OK' end where BR=@BR and cast(ReportDate as date)=@CurrentDT 

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


create proc SP_GETLatestBlotterDTLReportForToday(@BR int)
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
UpdateDate From SBP_BlotterCRRReportDaysWiseBal where cast(ReportDate as date)=cast(GETDATE() as date)


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


--truncate table SBP_BlotterManualData
--drop table SBP_BlotterManualData
create table SBP_BlotterManualData(
SNo bigint identity not null,
DataType varchar(100),
Inflow numeric,
OutFlow numeric,
NetBalance numeric,
DateFor DateTime,
UserID int not null Constraint FK_SBP_BlotterManualData_UserID Foreign key References SBP_LoginInfo(ID),
CreateDate DATETIME,
UpdateDate DATETIME,
BR int,
CurID int not null Constraint FK_SBP_BlotterManualData_CurID Foreign key References Currencies(CID),
Flag varchar(2),
Constraint PK_SBP_BlotterManualData_SNo primary key  clustered (SNo))


select* from SBP_BlotterManualData

--insert into SBP_BlotterManualData(DataType,Inflow,OutFlow,NetBalance,DateFor,UserID,CreateDate,BR,CurID) values('DLDT',150000000,130000000,150000000+130000000,GETDATE(),10,GETDATE(),1,1)
--insert into SBP_BlotterManualData(DataType,Inflow,OutFlow,NetBalance,DateFor,UserID,CreateDate,BR,CurID) values('SPSH',850000000,490000000,850000000+490000000,GETDATE(),10,GETDATE(),1,1)
--insert into SBP_BlotterManualData(DataType,Inflow,OutFlow,NetBalance,DateFor,UserID,CreateDate,BR,CurID) values('FXDH',90000000,70000000,90000000+70000000,GETDATE(),10,GETDATE(),1,1)
--insert into SBP_BlotterManualData(DataType,Inflow,OutFlow,NetBalance,DateFor,UserID,CreateDate,BR,CurID) values('RPRH',432000000,23500000,432000000+23500000,GETDATE(),10,GETDATE(),1,1)
--insert into SBP_BlotterManualData(DataType,Inflow,OutFlow,NetBalance,DateFor,UserID,CreateDate,BR,CurID) values('TPOS',100000,90000,100000+90000,GETDATE(),10,GETDATE(),1,1)
--insert into SBP_BlotterManualData(DataType,Inflow,OutFlow,NetBalance,DateFor,UserID,CreateDate,BR,CurID) values('Bond',189520000,125840000,189520000+125840000,GETDATE(),10,GETDATE(),1,1)


alter proc SP_GetOPICSManualData(@BR int,@Date Datetime)
as
select SNo,DataType,Inflow,OutFlow,NetBalance,DateFor From SBP_BlotterManualData where cast(DateFor as date)=cast(@Date as date) and BR=@BR

--drop table SBP_BlotterTransactionsTotal
create table SBP_BlotterTransactionsTotal(
SNo bigint identity not null,
InFlow numeric,
OutFlow numeric,
ClosingBal numeric,
DateFor Datetime,
BR int,
Constraint PK_SBP_BlotterTransactionsTotal_SNo primary key  clustered (SNo)
)

--truncate table SBP_BlotterTransactionsTotal
select* From SBP_BlotterTransactionsTotal

--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,88834000000,'2021-03-19',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,88834000000,'2021-03-20',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,88834000000,'2021-03-21',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,68619000000,'2021-03-22',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,80191250000,'2021-03-23',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,53036490000,'2021-03-24',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,57749500000,'2021-03-25',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,81963400000,'2021-03-26',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,81963400000,'2021-03-27',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,81963400000,'2021-03-28',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,86036600000,'2021-03-29',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,91475970000,'2021-03-30',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,112480600000,'2021-03-31',1)
--insert into SBP_BlotterTransactionsTotal(InFlow,OutFlow,ClosingBal,DateFor,BR) values(0,0,134200000000,'2021-04-01',1)



drop table SBP_BlotterSessionDetails
CREATE TABLE SBP_BlotterSessionDetails(
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[SessionID] [varchar](500) NULL,
	[UserID] [int] NOT NULL  Constraint FK_SBP_BlotterSessionDetails_UserID Foreign key References SBP_LoginInfo(ID),
	[IP] [nvarchar](100) NULL,
	[Status] [varchar](50) NULL,
	[URL] [nvarchar](100) NULL,
	[Activity]  [nvarchar](100) NULL,
	[ActivityTime] [datetime] NULL,
	[Data] [nvarchar](MAX) NULL,
	[SessionStart] [datetime] NULL,
	[SessionEnd] [datetime] NULL,
	[LoginStatus] [bit] NULL,
	[LoginGUID] [nvarchar](100) NULL)

	Select* from SBP_BlotterSessionDetails order by ID

creaTE PROCEDURE [dbo].[SP_ADD_SessionStart]
(
@pSessionID VARCHAR(500),
@pUserID INT,
@pIP VARCHAR(100),
@pLoginGUID VARCHAR(50),
@pLoginTime DATETIME = NULL,
@pExpires DATETIME = NULL
)
AS

BEGIN

	
		--INSERT tbl_Session (SessionID, UserID, [IP], ActivityTime, SessionStart, SessionEnd, LoginStatus, LoginGUID)
		--VALUES (@pSessionID, @pUserID, @pIP, GetDate(), @pLoginTime, @pExpires, 1, @pLoginGUID)

		INSERT SBP_BlotterSessionDetails (SessionID, UserID, [IP], ActivityTime, SessionStart, LoginStatus, LoginGUID)
		VALUES (@pSessionID, @pUserID, @pIP, GetDate(), @pExpires, 1, @pLoginGUID)
	
		UPDATE SBP_LoginInfo
			SET 
				isLoggedIn = 1
			Where 
				ID = @pUserID;


END;


alter PROCEDURE [dbo].[SP_SBPSessionStop]
(
@pSessionID VARCHAR(500),
@pUserID INT
)
AS

BEGIN

		--INSERT tbl_session (SessionID, UserID, IP, ActivityTime, SessionStart, LoginStatus, LoginGUID)
		--VALUES (@pSessionID, @pUserID, @pIP, GetDate(), GetDate(), 1, @pLoginGUID)

		UPDATE SBP_LoginInfo
			SET 
				isLoggedIn = 0
			Where 
				ID = @pUserID;


		UPDATE SBP_BlotterSessionDetails
			SET 
				LoginStatus = 0,
				SessionEnd = GetDate()
			Where 
				UserID = @pUserID AND
				ID = (Select Max(ID) From SBP_BlotterSessionDetails Where UserID = @pUserID)

END;


alter PROCEDURE [dbo].[SP_ADD_ActivityMonitor]
(
@pSessionID VARCHAR(500),
@pUserID INT,
@pIP NVARCHAR(100),
@pLoginGUID VARCHAR(50),
@pData VARCHAR(MAX),
@pActivity  VARCHAR(50),
@pURL NVARCHAR(100)
)
AS

BEGIN



		INSERT SBP_BlotterSessionDetails (SessionID, UserID, [IP],LoginGUID,[Activity], ActivityTime,[URL],[Data])
		VALUES (@pSessionID, @pUserID, @pIP, @pLoginGUID,@pActivity, GetDate(),@pURL,@pData)



END;




