CREATE TABLE [AccountingEvents]
(
	[AccountingEventsId] INT NOT NULL IDENTITY (208,1),
	[Code]               NVARCHAR(80),
	[Name]               NVARCHAR(80)
);

CREATE TABLE [Accounts]
(
	[AccountsId]         INT NOT NULL IDENTITY (64047,1),
	[Code]               NVARCHAR(80),
	[alCode]             NVARCHAR(80),
	[ObjectiveCode]      NVARCHAR(80),
	[NpmCode]            NVARCHAR(80),
	[NpmName]            NVARCHAR(80),
	[ProgramProjectCode] NVARCHAR(80),
	[ProgramProjectName] NVARCHAR(80),
	[ProgramAreaCode]    NVARCHAR(80),
	[ProgramAreaName]    NVARCHAR(80),
	[ActivityCode]       NVARCHAR(80),
	[ActivityName]       NVARCHAR(80),
	[AgencyActivity]     NVARCHAR(80)
);

CREATE TABLE [ActivityCodes]
(
	[ActivityId]  INT          NOT NULL IDENTITY (607,1),
	[Code]        NVARCHAR(80) NOT NULL,
	[Name]        NVARCHAR(80),
	[Description] NVARCHAR(80)
);

CREATE TABLE [Actuals]
(
	[ActualsId]            INT NOT NULL IDENTITY (13334,1),
	[BFY]                  NVARCHAR(80),
	[EFY]                  NVARCHAR(80),
	[RpioCode]             NVARCHAR(80),
	[RpioName]             NVARCHAR(80),
	[AhCode]               NVARCHAR(80),
	[AhName]               NVARCHAR(80),
	[FundCode]             NVARCHAR(80),
	[FundName]             NVARCHAR(80),
	[AppropriationCode]    NVARCHAR(80),
	[AppropriationName]    NVARCHAR(80),
	[SubAppropriationCode] NVARCHAR(80),
	[SubAppropriationName] NVARCHAR(80),
	[OrgCode]              NVARCHAR(80),
	[OrgName]              NVARCHAR(80),
	[AccountCode]          NVARCHAR(80),
	[ProgramProjectCode]   NVARCHAR(80),
	[ProgramProjectName]   NVARCHAR(80),
	[RpioActivityCode]     NVARCHAR(80),
	[RpioActivityName]     NVARCHAR(80),
	[BocCode]              NVARCHAR(80),
	[BocName]              NVARCHAR(80),
	[ULO]                  DECIMAL(18, 0),
	[Obligations]          DECIMAL(18, 0),
	[Balance]              DECIMAL(18, 0),
	[ProgramAreaCode]      NVARCHAR(80),
	[ProgramAreaName]      NVARCHAR(80),
	[alCode]               NVARCHAR(80),
	[alName]               NVARCHAR(80),
	[ObjectiveCode]        NVARCHAR(80),
	[ObjectiveName]        NVARCHAR(80)
);

CREATE TABLE [AdministrativeRequests]
(
	[AdministrativeRequestsId] INT NOT NULL IDENTITY (28,1),
	[RequestId]                INT,
	[ControlTeamAnalyst]       NVARCHAR(255),
	[RpioCode]                 NVARCHAR(255),
	[DocumentTitle]            NVARCHAR(255),
	[Amount]                   DECIMAL(18, 0),
	[FundCode]                 NVARCHAR(255),
	[BFY]                      NVARCHAR(255),
	[Status]                   NVARCHAR(255),
	[OriginalRequestDate]      DATETIME,
	[LastActivityDate]         DATETIME,
	[Duration]                 FLOAT,
	[BFS]                      NVARCHAR(255),
	[Comments]                 NTEXT,
	[RequestDocument]          NTEXT,
	[RequestType]              NVARCHAR(255),
	[TypeCode]                 NVARCHAR(255),
	[Decision]                 NVARCHAR(255)
);

CREATE TABLE [Allocations]
(
	[AllocationsId]      INT            NOT NULL IDENTITY (82051,1),
	[StatusOfFundsId]    INT            NOT NULL,
	[BudgetLevel]        NVARCHAR(80),
	[RpioCode]           NVARCHAR(80),
	[BFY]                NVARCHAR(80),
	[EFY]                NVARCHAR(80),
	[AhCode]             NVARCHAR(80),
	[FundCode]           NVARCHAR(80),
	[OrgCode]            NVARCHAR(80),
	[AccountCode]        NVARCHAR(80),
	[BocCode]            NVARCHAR(80),
	[RcCode]             NVARCHAR(80),
	[Amount]             DECIMAL(18, 0) NOT NULL DEFAULT (0),
	[RpioName]           NVARCHAR(80),
	[FundName]           NVARCHAR(80),
	[AhName]             NVARCHAR(80),
	[BocName]            NVARCHAR(80),
	[RcName]             NVARCHAR(80),
	[OrgName]            NVARCHAR(80),
	[NpmName]            NVARCHAR(80),
	[NpmCode]            NVARCHAR(80),
	[ProgramProjectCode] NVARCHAR(80),
	[ProgramProjectName] NVARCHAR(80),
	[ProgramAreaCode]    NVARCHAR(80),
	[ProgramAreaName]    NVARCHAR(80)
);

CREATE TABLE [AllowanceHolders]
(
	[AllowanceHoldersId] INT NOT NULL IDENTITY (6126,1),
	[Code]               NVARCHAR(80),
	[Name]               NVARCHAR(80)
);

CREATE TABLE [AmericanRescuePlan]
(
	[AmericanRescuePlanId] INT NOT NULL,
	[StatusOfFundsId]      INT NOT NULL,
	[BudgetLevel]          NVARCHAR(80),
	[BFY]                  NVARCHAR(80),
	[EFY]                  NVARCHAR(80),
	[FundCode]             NVARCHAR(80),
	[FundName]             NVARCHAR(80),
	[RpioCode]             NVARCHAR(80),
	[RpioName]             NVARCHAR(80),
	[AhCode]               NVARCHAR(80),
	[AhName]               NVARCHAR(80),
	[OrgCode]              NVARCHAR(80),
	[OrgName]              NVARCHAR(80),
	[AccountCode]          NVARCHAR(80),
	[BocCode]              NVARCHAR(80),
	[BocName]              NVARCHAR(80),
	[ProgramProjectCode]   NVARCHAR(80),
	[ProgramProjectName]   NVARCHAR(80),
	[ProgramAreaCode]      NVARCHAR(80),
	[ProgramAreaName]      NVARCHAR(80),
	[RcCode]               NVARCHAR(80),
	[RcName]               NVARCHAR(80),
	[LowerName]            NVARCHAR(80),
	[Amount]               DECIMAL(18, 0),
	[Budgeted]             DECIMAL(18, 0),
	[Posted]               DECIMAL(18, 0),
	[OpenCommitments]      DECIMAL(18, 0),
	[ULO]                  DECIMAL(18, 0),
	[Expenditures]         DECIMAL(18, 0),
	[Obligations]          DECIMAL(18, 0),
	[Used]                 DECIMAL(18, 0),
	[Available]            DECIMAL(18, 0),
	[NpmCode]              NVARCHAR(80),
	[NpmName]              NVARCHAR(80)
);

CREATE TABLE [AmericanRescuePlanCarryoverEstimates]
(
	[AmericanRescuePlanCarryoverEstimatesId] INT NOT NULL IDENTITY (1,1),
	[BFY]                                    NVARCHAR(80),
	[EFY]                                    NVARCHAR(80),
	[TreasuryAccountCode]                    NVARCHAR(80),
	[FundCode]                               NVARCHAR(80),
	[FundName]                               NVARCHAR(80),
	[RpioCode]                               NVARCHAR(80),
	[RpioName]                               NVARCHAR(80),
	[Amount]                                 FLOAT,
	[OpenCommitments]                        FLOAT,
	[Obligations]                            FLOAT,
	[Available]                              FLOAT,
	[Estimate]                               FLOAT
);

CREATE TABLE [AnnualCarryoverEstimates]
(
	[AnnualCarryoverEstimatesId] INT NOT NULL IDENTITY (6758,1),
	[BFY]                        NVARCHAR(80),
	[EFY]                        NVARCHAR(80),
	[FundCode]                   NVARCHAR(80),
	[FundName]                   NVARCHAR(80),
	[TreasuryAccountCode]        NVARCHAR(80),
	[RpioCode]                   NVARCHAR(80),
	[RpioName]                   NVARCHAR(80),
	[Amount]                     DECIMAL(18, 0),
	[OpenCommitments]            DECIMAL(18, 0),
	[Obligations]                DECIMAL(18, 0),
	[Available]                  DECIMAL(18, 0),
	[Estimate]                   DECIMAL(18, 0)
);

CREATE TABLE [AnnualCarryoverSurvey]
(
	[AnnualCarryoverSurveyId] INT NOT NULL IDENTITY (300,1),
	[BFY]                     NVARCHAR(80),
	[FundCode]                NVARCHAR(80),
	[FundName]                NVARCHAR(80),
	[TreasuryAccountCode]     NVARCHAR(80),
	[Amount]                  DECIMAL(18, 0)
);

CREATE TABLE [AnnualReimbursableEstimates]
(
	[AnnualReimbursableEstimatesId] INT NOT NULL IDENTITY (796,1),
	[BFY]                           NVARCHAR(80),
	[EFY]                           NVARCHAR(80),
	[FundCode]                      NVARCHAR(80),
	[FundName]                      NVARCHAR(80),
	[TreasuryAccountCode]           NVARCHAR(80),
	[RpioCode]                      NVARCHAR(80),
	[RpioName]                      NVARCHAR(80),
	[Amount]                        DECIMAL(18, 0),
	[OpenCommitments]               DECIMAL(18, 0),
	[Obligations]                   DECIMAL(18, 0),
	[Available]                     DECIMAL(18, 0),
	[Estimate]                      DECIMAL(18, 0)
);

CREATE TABLE [AnnualReimbursableSurvey]
(
	[AnnualReimbursableSurveyId] INT NOT NULL IDENTITY (2,1),
	[BFY]                        NVARCHAR(80),
	[FundCode]                   NVARCHAR(80),
	[FundName]                   NVARCHAR(80),
	[Amount]                     DECIMAL(18, 0)
);

CREATE TABLE [ApplicationTables]
(
	[ApplicationTablesId] INT NOT NULL IDENTITY (1869,1),
	[TableName]           NVARCHAR(80),
	[Model]               NVARCHAR(80)
);

CREATE TABLE [ApportionmentData]
(
	[ApportionmentDataId]                 INT NOT NULL IDENTITY (2080,1),
	[FiscalYear]                          NVARCHAR(80),
	[BFY]                                 NVARCHAR(80),
	[EFY]                                 NVARCHAR(80),
	[TreasuryAppropriationFundSymbol]     NVARCHAR(80),
	[TreasuryAppropriationFundSymbolName] NVARCHAR(80),
	[ApportionmentAccountCode]            NVARCHAR(80),
	[ApportionmentAccountName]            NVARCHAR(80),
	[AvailabilityType]                    NVARCHAR(80),
	[BudgetAccountCode]                   NVARCHAR(80),
	[BudgetAccountName]                   NVARCHAR(80),
	[ApprovalDate]                        DATETIME,
	[LineNumber]                          NVARCHAR(80),
	[LineName]                            NVARCHAR(80),
	[Amount]                              DECIMAL(18, 0)
);

CREATE TABLE [AppropriationAvailableBalances]
(
	[AppropriationAvailableBalancesId] INT NOT NULL IDENTITY (1299,1),
	[BFY]                              NVARCHAR(80),
	[EFY]                              NVARCHAR(80),
	[AppropriationFundCode]            NVARCHAR(80),
	[AppropriationFundName]            NVARCHAR(80),
	[TreasurySymbol]                   NVARCHAR(80),
	[OmbAccountCode]                   NVARCHAR(80),
	[Availability]                     NVARCHAR(80),
	[TotalAuthority]                   DECIMAL(18, 0),
	[TotalUsed]                        DECIMAL(18, 0),
	[Available]                        DECIMAL(18, 0)
);

CREATE TABLE [AppropriationDocuments]
(
	[AppropriationDocumentsId]      INT NOT NULL IDENTITY (2345,1),
	[FiscalYear]                    NVARCHAR(80),
	[BFY]                           NVARCHAR(80),
	[EFY]                           NVARCHAR(80),
	[AppropriationFund]             NVARCHAR(80),
	[FundCode]                      NVARCHAR(80),
	[DocumentType]                  NVARCHAR(80),
	[DocumentNumber]                NVARCHAR(80),
	[DocumentDate]                  DATETIME,
	[LastDocumentDate]              DATETIME,
	[BudgetLevel]                   NVARCHAR(80),
	[BudgetingControls]             NVARCHAR(80),
	[PostingControls]               NVARCHAR(80),
	[PreCommitmentControls]         NVARCHAR(80),
	[CommitmentControls]            NVARCHAR(80),
	[ObligationControls]            NVARCHAR(80),
	[AccrualControls]               NVARCHAR(80),
	[ExpenditureControls]           NVARCHAR(80),
	[ExpenseControls]               NVARCHAR(80),
	[ReimbursementControls]         NVARCHAR(80),
	[ReimbursableAgreementControls] NVARCHAR(80),
	[Budgeted]                      DECIMAL(18, 0) DEFAULT (0),
	[Posted]                        DECIMAL(18, 0) DEFAULT (0),
	[CarryOut]                      DECIMAL(18, 0) DEFAULT (0),
	[CarryIn]                       DECIMAL(18, 0) DEFAULT (0),
	[EstimatedReimbur0sements]      DECIMAL(18, 0) DEFAULT (0),
	[EstimatedRecoveries]           DECIMAL(18, 0) DEFAULT (0)
);

CREATE TABLE [AppropriationLevelAuthority]
(
	[AppropriationLevelAuthorityId] INT NOT NULL IDENTITY (939,1),
	[BudgetAccountCode]             NVARCHAR(80),
	[BudgetAccountName]             NVARCHAR(80),
	[FiscalYear]                    NVARCHAR(80),
	[FundCode]                      NVARCHAR(80),
	[FundName]                      NVARCHAR(80),
	[Budgeted]                      DECIMAL(18, 0),
	[Posted]                        DECIMAL(18, 0),
	[CarryOut]                      DECIMAL(18, 0),
	[CarryIn]                       DECIMAL(18, 0),
	[EstimatedReimbursements]       DECIMAL(18, 0),
	[EstimatedRecoveries]           DECIMAL(18, 0)
);

CREATE TABLE [Appropriations]
(
	[AppropriationsId] INT          NOT NULL IDENTITY (11,1),
	[BFY]              NVARCHAR(80) NOT NULL,
	[Title]            NVARCHAR(80),
	[PublicLaw]        NVARCHAR(80),
	[EnactedDate]      DATETIME
);

CREATE TABLE [BudgetaryResourceExecution]
(
	[BudgetaryResourceExecutionId] INT NOT NULL IDENTITY (14806,1),
	[FiscalYear]                   NVARCHAR(80),
	[BFY]                          NVARCHAR(80),
	[EFY]                          NVARCHAR(80),
	[LastUpdate]                   DATETIME,
	[TreasurySymbol]               NVARCHAR(80),
	[OmbAccount]                   NVARCHAR(80),
	[TreasuryAgencyCode]           NVARCHAR(80),
	[TreasuryAccountCode]          NVARCHAR(80),
	[STAT]                         NVARCHAR(80),
	[CreditIndicator]              NVARCHAR(80),
	[LineNumber]                   NVARCHAR(80),
	[LineDescription]              NVARCHAR(80),
	[SectionName]                  NVARCHAR(80),
	[SectionNumber]                NVARCHAR(80),
	[LineType]                     NVARCHAR(80),
	[FinancingAccounts]            NVARCHAR(80),
	[November]                     DECIMAL(18, 0),
	[January]                      DECIMAL(18, 0),
	[Feburary]                     DECIMAL(18, 0),
	[April]                        DECIMAL(18, 0),
	[May]                          DECIMAL(18, 0),
	[June]                         DECIMAL(18, 0),
	[August]                       DECIMAL(18, 0),
	[October]                      DECIMAL(18, 0),
	[Amount1]                      DECIMAL(18, 0),
	[Amount2]                      DECIMAL(18, 0),
	[Amount3]                      DECIMAL(18, 0),
	[Amount4]                      DECIMAL(18, 0),
	[Agency]                       NVARCHAR(80),
	[Bureau]                       NVARCHAR(80)
);

CREATE TABLE [BudgetControls]
(
	[BudgetControlsId]                     INT NOT NULL IDENTITY (1486,1),
	[Code]                                 NVARCHAR(80),
	[Name]                                 NVARCHAR(80),
	[BudgetedTransType]                    NVARCHAR(80),
	[PostedTransType]                      NVARCHAR(80),
	[EstimatedReimbursementsTransType]     NVARCHAR(80),
	[SpendingAdjustmentTransType]          NVARCHAR(80),
	[EstimatedRecoveriesTransType]         NVARCHAR(80),
	[ActualRecoveriesTransType]            NVARCHAR(80),
	[StatusReserveTransType]               NVARCHAR(80),
	[ProfitLossTransType]                  NVARCHAR(80),
	[EstimatedReimbursementsSpendinption]  NVARCHAR(80),
	[EstimatedReimursementsBudgetinption]  NVARCHAR(80),
	[TrackAgreementLowerLevel]             NVARCHAR(80),
	[BudgetEstimatedLowerLevel]            NVARCHAR(80),
	[EstimatedRecoveriesSpendinption]      NVARCHAR(80),
	[EstimatedRecoveriesBudgetinption]     NVARCHAR(80),
	[RecoveryNextLevel]                    NVARCHAR(80),
	[RecoveryBudgetMismatch]               NVARCHAR(80),
	[ProfitLossSpendinption]               NVARCHAR(80),
	[ProfitLossBudgetOption]               NVARCHAR(80),
	[RecoveriesCarryInLowerLevel]          NVARCHAR(80),
	[RecoveriesCarryInLowerLevelControl]   NVARCHAR(80),
	[RecoveriesCarryInAmountControl]       NVARCHAR(80),
	[BudgetedControl]                      NVARCHAR(80),
	[PostedControl]                        NVARCHAR(80),
	[PreCommitmentSpendingControl]         NVARCHAR(80),
	[CommitmentSpendingControl]            NVARCHAR(80),
	[ObligationSpendingControl]            NVARCHAR(80),
	[AccrualSpendingControl]               NVARCHAR(80),
	[ExpenditureSpendingControl]           NVARCHAR(80),
	[ExpenseSpendingControl]               NVARCHAR(80),
	[ReimbursableSpendingControl]          NVARCHAR(80),
	[ReimbursableAgreementSpendingControl] NVARCHAR(80),
	[FteBudgetingControl]                  NVARCHAR(80),
	[FteSpendingControl]                   NVARCHAR(80),
	[TransactionTypeControl]               NVARCHAR(80),
	[AuthorityDistributionControl]         NVARCHAR(80)
);

CREATE TABLE [BudgetDocuments]
(
	[BudgetDocumentsId]             INT NOT NULL IDENTITY (1796157,1),
	[BFY]                           NVARCHAR(80),
	[EFY]                           NVARCHAR(80),
	[BudgetLevel]                   NVARCHAR(80),
	[DocumentDate]                  DATETIME,
	[LastDocumentDate]              DATETIME,
	[DocumentType]                  NVARCHAR(80),
	[DocumentNumber]                NVARCHAR(80),
	[FundCode]                      NVARCHAR(80),
	[FundName]                      NVARCHAR(80),
	[RpioCode]                      NVARCHAR(80),
	[RpioName]                      NVARCHAR(80),
	[AhCode]                        NVARCHAR(80),
	[AhName]                        NVARCHAR(80),
	[OrgCode]                       NVARCHAR(80),
	[OrgName]                       NVARCHAR(80),
	[AccountCode]                   NVARCHAR(80),
	[ProgramProjectName]            NVARCHAR(80),
	[ProgramAreaCode]               NVARCHAR(80),
	[ProgramAreaName]               NVARCHAR(80),
	[BocCode]                       NVARCHAR(80),
	[BocName]                       NVARCHAR(80),
	[ReimbursableAgreementControls] NVARCHAR(80),
	[BudgetingControls]             NVARCHAR(80),
	[PostingControls]               NVARCHAR(80),
	[PreCommitmentControls]         NVARCHAR(80),
	[CommitmentControls]            NVARCHAR(80),
	[ObligationControls]            NVARCHAR(80),
	[ExpenditureControls]           NVARCHAR(80),
	[ExpenseControls]               NVARCHAR(80),
	[AccrualControls]               NVARCHAR(80),
	[ReimbursementControls]         NVARCHAR(80),
	[Budgeted]                      DECIMAL(18, 0),
	[Posted]                        DECIMAL(18, 0),
	[CarryOut]                      DECIMAL(18, 0),
	[CarryIn]                       DECIMAL(18, 0),
	[EstimatedRecoveries]           DECIMAL(18, 0),
	[EstimatedReimbursements]       DECIMAL(18, 0)
);

CREATE TABLE [BudgetObjectClasses]
(
	[BudgetObjectClassesId] INT NOT NULL IDENTITY (18,1),
	[Code]                  NVARCHAR(80),
	[Name]                  NVARCHAR(80)
);

CREATE TABLE [BudgetOutlays]
(
	[BudgetOutlaysId] INT NOT NULL IDENTITY (279,1),
	[ReportYear]      NVARCHAR(80),
	[AgencyName]      NVARCHAR(80),
	[OmbAccount]      NVARCHAR(80),
	[Line]            NVARCHAR(80),
	[LineNumber]      NVARCHAR(80),
	[LineSection]     NVARCHAR(80),
	[LineName]        NVARCHAR(80),
	[BeaCatery]       NVARCHAR(80),
	[BeaCateryName]   NVARCHAR(80),
	[LineCatery]      NVARCHAR(80),
	[PriorYear]       DECIMAL(18, 0),
	[CurrentYear]     DECIMAL(18, 0),
	[BudgetYear]      DECIMAL(18, 0),
	[OutYear1]        DECIMAL(18, 0),
	[OutYear2]        DECIMAL(18, 0),
	[OutYear3]        DECIMAL(18, 0),
	[OutYear4]        DECIMAL(18, 0),
	[OutYear5]        DECIMAL(18, 0),
	[OutYear6]        DECIMAL(18, 0),
	[OutYear7]        DECIMAL(18, 0),
	[OutYear8]        DECIMAL(18, 0),
	[OutYear9]        DECIMAL(18, 0)
);

CREATE TABLE [CapitalPlanningInvestmentCodes]
(
	[CapitalPlanningInvestmentCodesId] INT NOT NULL IDENTITY (672,1),
	[Type]                             NVARCHAR(80),
	[Code]                             NVARCHAR(80),
	[Name]                             NVARCHAR(80)
);

CREATE TABLE [CarryoverApportionments]
(
	[CarryoverApportionmentsId] INT NOT NULL IDENTITY (99,1),
	[BudgetAccount]             NVARCHAR(80),
	[TreasuryAccount]           NVARCHAR(80),
	[BFY]                       NVARCHAR(80),
	[EFY]                       NVARCHAR(80),
	[Group]                     NVARCHAR(80),
	[Description]               NVARCHAR(80),
	[LineName]                  NVARCHAR(80),
	[AuthorityType]             NVARCHAR(80),
	[Request]                   DECIMAL(18, 0),
	[Balance]                   DECIMAL(18, 0),
	[Deobligations]             DECIMAL(18, 0),
	[Amount]                    DECIMAL(18, 0),
	[LineNumber]                NVARCHAR(80),
	[LineSplit]                 NVARCHAR(80),
	[ApportionmentAccountCode]  NVARCHAR(80),
	[TreasuryAccountCode]       NVARCHAR(80),
	[TreasuryAccountName]       NVARCHAR(80),
	[BudgetAccountCode]         NVARCHAR(80),
	[BudgetAccountName]         NVARCHAR(80)
);

CREATE TABLE [CarryoverRequests]
(
	[CarryoverRequestsId] INT NOT NULL IDENTITY (13,1),
	[ControlTeamAnalyst]  NVARCHAR(80),
	[RpioCode]            NVARCHAR(80),
	[DocumentTitle]       NVARCHAR(80),
	[Amount]              DECIMAL(18, 0),
	[FundCode]            NVARCHAR(80),
	[Status]              NVARCHAR(80),
	[OriginalRequestDate] DATETIME,
	[LastActivityDate]    DATETIME,
	[BFS]                 NVARCHAR(80),
	[Comments]            NTEXT,
	[RequestDocument]     NTEXT,
	[Duration]            INT
);

CREATE TABLE [Changes]
(
	[ChangesId] INT NOT NULL IDENTITY (4194,1),
	[TableName] NVARCHAR(80),
	[FieldName] NVARCHAR(80),
	[Action]    NVARCHAR(80),
	[OldValue]  NVARCHAR(80),
	[NewValue]  NVARCHAR(80),
	[TimeStamp] DATETIME,
	[Message]   NVARCHAR(80)
);

CREATE TABLE [CompassLevels]
(
	[CompassLevelsId]                          INT NOT NULL IDENTITY (252402,1),
	[BudgetLevel]                              NVARCHAR(80),
	[BFY]                                      NVARCHAR(80),
	[EFY]                                      NVARCHAR(80),
	[FundCode]                                 NVARCHAR(80),
	[FundName]                                 NVARCHAR(80),
	[AppropriationCode]                        NVARCHAR(80),
	[SubAppropriationCode]                     NVARCHAR(80),
	[AppropriationName]                        NVARCHAR(80),
	[DocumentType]                             NVARCHAR(80),
	[TreasurySymbol]                           NVARCHAR(80),
	[OmbAccount]                               NVARCHAR(80),
	[PostedControlFlag]                        NVARCHAR(80),
	[ActualRecoveryTransType]                  NVARCHAR(80),
	[CommitmentSpendingControlFlag]            NVARCHAR(80),
	[BudgetDefault]                            NVARCHAR(80),
	[LowerChildExpenditureSpendingControlFlag] NVARCHAR(80),
	[LowerChildExpenseSpendingControlFlag]     NVARCHAR(80),
	[FteControlFlag]                           NVARCHAR(80),
	[AccrualSpendingControlFlag]               NVARCHAR(80),
	[ObligationSpendingControlFlag]            NVARCHAR(80),
	[PreCommitmentSpendingControlFlag]         NVARCHAR(80),
	[LowerCommitmentSpendingControlFlag]       NVARCHAR(80),
	[LowerObligationSpendingControlFlag]       NVARCHAR(80),
	[LowerExpenditureSpendingControlFlag]      NVARCHAR(80),
	[LowerExpenseSpendingControlFlag]          NVARCHAR(80),
	[LowerPostedControlFlag]                   NVARCHAR(80),
	[LowerPostedTransType]                     NVARCHAR(80),
	[LowerTransType]                           NVARCHAR(80),
	[LowerPostedFlag]                          NVARCHAR(80),
	[LowerPreCommitmentSpendingControlFlag]    NVARCHAR(80),
	[LowerRecoveriesSpendinption]              NVARCHAR(80),
	[LowerRecoveriesOption]                    NVARCHAR(80),
	[LowerReimbursableSpendinption]            NVARCHAR(80),
	[Date]                                     DATETIME,
	[TotalAuthority]                           DECIMAL(18, 0),
	[OriginalAmount]                           DECIMAL(18, 0),
	[CarryoverAvailabilityPercentage]          DECIMAL(18, 0),
	[CarryIn]                                  DECIMAL(18, 0),
	[CarryOut]                                 DECIMAL(18, 0),
	[FundsIn]                                  DECIMAL(18, 0),
	[FundsOut]                                 DECIMAL(18, 0),
	[RecoveriesWithdrawn]                      DECIMAL(18, 0),
	[ActualRecoveries]                         DECIMAL(18, 0),
	[ActualReimbursements]                     DECIMAL(18, 0),
	[AgreementReimbursables]                   DECIMAL(18, 0)
);

CREATE TABLE [CompassOutlays]
(
	[CompassOutlaysId]        INT NOT NULL IDENTITY (3204,1),
	[BFY]                     NVARCHAR(80),
	[EFY]                     NVARCHAR(80),
	[FundCode]                NVARCHAR(80),
	[FundName]                NVARCHAR(80),
	[AppropriationCode]       NVARCHAR(80),
	[AppropriationName]       NVARCHAR(80),
	[TreasurySymbol]          NVARCHAR(80),
	[ProgramAreaCode]         NVARCHAR(80),
	[ProgramAreaName]         NVARCHAR(80),
	[ProgramProjectCode]      NVARCHAR(80),
	[ProgramProjectName]      NVARCHAR(80),
	[BocCode]                 NVARCHAR(80),
	[BocName]                 NVARCHAR(80),
	[TotalObligations]        DECIMAL(18, 0),
	[UnliquidatedObligations] DECIMAL(18, 0),
	[ObligationsPaid]         DECIMAL(18, 0)
);

CREATE TABLE [CongressionalControls]
(
	[CongressionalControlsId]  INT NOT NULL IDENTITY (187,1),
	[FundCode]                 NVARCHAR(80),
	[FundName]                 NVARCHAR(80),
	[ProgramAreaCode]          NVARCHAR(80),
	[ProgramAreaName]          NVARCHAR(80),
	[ProgramProjectCode]       NVARCHAR(80),
	[ProgramProjectName]       NVARCHAR(80),
	[SubProjectCode]           NVARCHAR(80),
	[SubProjectName]           NVARCHAR(80),
	[ReprogrammingRestriction] NVARCHAR(80),
	[IncreaseRestriction]      NVARCHAR(80),
	[DecreaseRestriction]      NVARCHAR(80),
	[MemoRequirement]          NVARCHAR(80)
);

CREATE TABLE [CongressionalReprogrammings]
(
	[CongressionalReprogrammingsId] INT NOT NULL IDENTITY (2,1),
	[ReprogrammingNumber]           NVARCHAR(80),
	[BFY]                           NVARCHAR(80),
	[EFY]                           NVARCHAR(80),
	[RpioCode]                      NVARCHAR(80),
	[AhCode]                        NVARCHAR(80),
	[AhName]                        NVARCHAR(80),
	[FundCode]                      NVARCHAR(80),
	[FundName]                      NVARCHAR(80),
	[AccountCode]                   NVARCHAR(80),
	[ProgramProjectCode]            NVARCHAR(80),
	[ProgramProjectName]            NVARCHAR(80),
	[ProgramAreaCode]               NVARCHAR(80),
	[ProgramAreaName]               NVARCHAR(80),
	[OrgCode]                       NVARCHAR(80),
	[OrgName]                       NVARCHAR(80),
	[BocCode]                       NVARCHAR(80),
	[BocName]                       NVARCHAR(80),
	[ActivityCode]                  NVARCHAR(80),
	[Amount]                        DECIMAL(18, 0),
	[Description]                   NVARCHAR(155),
	[ExtendedDescription]           NTEXT,
	[FromTo]                        NVARCHAR(80),
	[Cycle]                         NVARCHAR(80)
);

CREATE TABLE [Contacts]
(
	[ContactsId] INT NOT NULL IDENTITY (13,1),
	[FirstName]  NVARCHAR(80),
	[LastName]   NVARCHAR(80),
	[FullName]   NVARCHAR(80),
	[Email]      NVARCHAR(80),
	[RPIO]       NVARCHAR(80),
	[Section]    NVARCHAR(80)
);

CREATE TABLE [CostAreas]
(
	[CostAreasId] INT NOT NULL IDENTITY (40,1),
	[Code]        NVARCHAR(80),
	[Name]        NVARCHAR(80)
);

CREATE TABLE [DataRuleDescriptions]
(
	[DataRuleDescriptionsId] INT NOT NULL IDENTITY (1177,1),
	[Schedule]               NVARCHAR(80),
	[LineNumber]             NVARCHAR(80),
	[RuleNumber]             NVARCHAR(80),
	[RuleDescription]        NTEXT,
	[ScheduleOrder]          NVARCHAR(80)
);

CREATE TABLE [Defactos]
(
	[DefactosId]         INT NOT NULL,
	[StatusOfFundsId]    INT NOT NULL IDENTITY (16381,1),
	[BudgetLevel]        NVARCHAR(255),
	[BFY]                NVARCHAR(255),
	[EFY]                NVARCHAR(255),
	[RpioCode]           NVARCHAR(255),
	[RpioName]           NVARCHAR(255),
	[AhCode]             NVARCHAR(255),
	[AhName]             NVARCHAR(255),
	[FundCode]           NVARCHAR(255),
	[FundName]           NVARCHAR(255),
	[OrgCode]            NVARCHAR(255),
	[OrgName]            NVARCHAR(255),
	[AccountCode]        NVARCHAR(255),
	[RcCode]             NVARCHAR(255),
	[BocCode]            NVARCHAR(255),
	[BocName]            NVARCHAR(255),
	[ProgramProjectCode] NVARCHAR(255),
	[ProgramProjectName] NVARCHAR(255),
	[ProgramAreaCode]    NVARCHAR(255),
	[ProgramAreaName]    NVARCHAR(255),
	[RcName]             NVARCHAR(255),
	[LowerName]          NVARCHAR(255),
	[Amount]             MONEY,
	[Budgeted]           MONEY,
	[Posted]             MONEY,
	[OpenCommitments]    MONEY,
	[ULO]                MONEY,
	[Expenditures]       MONEY,
	[Obligations]        MONEY,
	[Used]               MONEY,
	[Available]          MONEY,
	[NpmCode]            NVARCHAR(255),
	[NpmName]            NVARCHAR(255)
);

CREATE TABLE [DeobligationActivity]
(
	[DeobligationActivityId] INT NOT NULL IDENTITY (1,1),
	[BFY]                    NVARCHAR(80),
	[EFY]                    NVARCHAR(80),
	[TreasuryAccountCode]    NVARCHAR(80),
	[BudgetAccountCode]      NVARCHAR(80),
	[FundCode]               NVARCHAR(80),
	[FundName]               NVARCHAR(80),
	[RpioCode]               NVARCHAR(80),
	[RpioName]               NVARCHAR(80),
	[AhCode]                 NVARCHAR(80),
	[AhName]                 NVARCHAR(80),
	[OrgCode]                NVARCHAR(80),
	[OrgName]                NVARCHAR(80),
	[AccountCode]            NVARCHAR(80),
	[ProgramProjectName]     NVARCHAR(80),
	[BocCode]                NVARCHAR(25),
	[BocName]                NVARCHAR(80),
	[DocumentNumber]         NVARCHAR(80),
	[ProcessedDate]          DATETIME,
	[Amount]                 FLOAT
);

CREATE TABLE [Deobligations]
(
	[DeobligationsId]    INT NOT NULL IDENTITY (2673710,1),
	[BFY]                NVARCHAR(80),
	[EFY]                NVARCHAR(80),
	[FundCode]           NVARCHAR(80),
	[FundName]           NVARCHAR(80),
	[TreasurySymbol]     NVARCHAR(80),
	[OmbAccountCode]     NVARCHAR(80),
	[OmbAccountName]     NVARCHAR(80),
	[RpioCode]           NVARCHAR(80),
	[RpioName]           NVARCHAR(80),
	[AhCode]             NVARCHAR(80),
	[AhName]             NVARCHAR(80),
	[AccountCode]        NVARCHAR(80),
	[NpmCode]            NVARCHAR(80),
	[NpmName]            NVARCHAR(80),
	[ProgramProjectCode] NVARCHAR(80),
	[ProgramProjectName] NVARCHAR(80),
	[OrgCode]            NVARCHAR(80),
	[OrgName]            NVARCHAR(80),
	[BocCode]            NVARCHAR(80),
	[BocName]            NVARCHAR(80),
	[DocumentNumber]     NVARCHAR(80),
	[FocCode]            NVARCHAR(80),
	[FocName]            NVARCHAR(80),
	[ProcessedDate]      DATETIME,
	[Amount]             DECIMAL(18, 0)
);

CREATE TABLE [DocumentControlNumbers]
(
	[DocumentControlNumbersId] INT NOT NULL IDENTITY (481758,1),
	[RpioCode]                 NVARCHAR(80),
	[RpioName]                 NVARCHAR(80),
	[DocumentType]             NVARCHAR(80),
	[DocumentNumber]           NVARCHAR(80),
	[DocumentPrefix]           NVARCHAR(80),
	[DocumentControlNumber]    NVARCHAR(80)
);

CREATE TABLE [Documents]
(
	[DocumentsId] INT NOT NULL IDENTITY (188,1),
	[Code]        NVARCHAR(80),
	[Catery]      NVARCHAR(80),
	[Name]        NVARCHAR(80),
	[System]      NVARCHAR(80)
);

CREATE TABLE [Earmarks]
(
	[EarmarksId]                INT NOT NULL IDENTITY (492,1),
	[RpioCode]                  NVARCHAR(80),
	[RpioName]                  NVARCHAR(80),
	[FundCode]                  NVARCHAR(80),
	[FundName]                  NVARCHAR(80),
	[StateCode]                 NVARCHAR(80),
	[Description]               NVARCHAR(80),
	[Amount]                    DECIMAL(18, 0),
	[ProjectOfficerLastName]    NVARCHAR(80),
	[ProjectOfficerFirstName]   NVARCHAR(80),
	[ProjectOfficerPhoneNumber] NVARCHAR(80),
	[ProjectOfficerMailCode]    NVARCHAR(80),
	[CommitmentDate]            DATETIME,
	[ObligationDate]            DATETIME,
	[ProjectStatus]             NVARCHAR(80),
	[ProjectOfficerComments]    NVARCHAR(80)
);

CREATE TABLE [ExecutionTables]
(
	[ExecutionTablesId] INT NOT NULL IDENTITY (571,1),
	[TableName]         NVARCHAR(80),
	[Type]              NVARCHAR(80)
);

CREATE TABLE [Expenditures]
(
	[ExpendituresId]        INT NOT NULL IDENTITY (272085,1),
	[ObligationsId]         INT,
	[BFY]                   NVARCHAR(80),
	[EFY]                   NVARCHAR(80),
	[RpioCode]              NVARCHAR(80),
	[RpioName]              NVARCHAR(80),
	[AhCode]                NVARCHAR(80),
	[AhName]                NVARCHAR(80),
	[FundCode]              NVARCHAR(80),
	[FundName]              NVARCHAR(80),
	[OrgCode]               NVARCHAR(80),
	[OrgName]               NVARCHAR(80),
	[AccountCode]           NVARCHAR(80),
	[ProgramProjectCode]    NVARCHAR(80),
	[ProgramProjectName]    NVARCHAR(80),
	[RcCode]                NVARCHAR(80),
	[RcName]                NVARCHAR(80),
	[DocumentType]          NVARCHAR(80),
	[DocumentNumber]        NVARCHAR(80),
	[DocumentControlNumber] NVARCHAR(80),
	[TreasuryAccountCode]   NVARCHAR(80),
	[TreasuryAccountName]   NVARCHAR(80),
	[BudgetAccountCode]     NVARCHAR(80),
	[BudgetAccountName]     NVARCHAR(255),
	[ProcessedDate]         DATETIME,
	[LastActivityDate]      DATETIME,
	[Age]                   NVARCHAR(80),
	[BocCode]               NVARCHAR(80),
	[BocName]               NVARCHAR(80),
	[FocCode]               NVARCHAR(80),
	[FocName]               NVARCHAR(80),
	[NpmCode]               NVARCHAR(80),
	[NpmName]               NVARCHAR(80),
	[VendorCode]            NVARCHAR(80),
	[VendorName]            NVARCHAR(80),
	[Amount]                DECIMAL(18, 0) DEFAULT (0)
);

CREATE TABLE [FederalHolidays]
(
	[FederalHolidaysId]    INT NOT NULL IDENTITY (15,1),
	[BFY]                  NVARCHAR(80),
	[ColumbusDay]          DATETIME,
	[VeteransDay]          DATETIME,
	[ThanksgivingDay]      DATETIME,
	[ChristmasDay]         DATETIME,
	[NewYears]             DATETIME,
	[MartinLutherKingsDay] DATETIME,
	[Washingtonsday]       DATETIME,
	[MemorialDay]          DATETIME,
	[JuneteenthDay]        DATETIME,
	[IndependenceDay]      DATETIME,
	[LaborDay]             DATETIME
);

CREATE TABLE [FinanceObjectClasses]
(
	[FinanceObjectClassesId] INT NOT NULL IDENTITY (486,1),
	[Code]                   NVARCHAR(80),
	[Name]                   NVARCHAR(80),
	[BocCode]                NVARCHAR(80),
	[BocName]                NVARCHAR(80)
);

CREATE TABLE [FiscalYears]
(
	[FiscalYearsId]        INT          NOT NULL IDENTITY (117,1),
	[BFY]                  NVARCHAR(80) NOT NULL,
	[EFY]                  NVARCHAR(80),
	[StartDate]            NVARCHAR(80),
	[ColumbusDay]          DATETIME,
	[VeteransDay]          DATETIME,
	[ThanksgivingDay]      DATETIME,
	[ChristmasDay]         DATETIME,
	[NewYearsDay]          DATETIME,
	[MartinLutherKingsDay] DATETIME,
	[WashingtonsDay]       DATETIME,
	[MemorialDay]          DATETIME,
	[JuneteenthDay]        DATETIME,
	[IndependenceDay]      DATETIME,
	[LaborDay]             DATETIME,
	[ExpiringYear]         NVARCHAR(80),
	[ExpirationDate]       NVARCHAR(80),
	[WorkDays]             FLOAT,
	[WeekDays]             FLOAT,
	[WeekEnds]             FLOAT,
	[EndDate]              NVARCHAR(80),
	[Availability]         NVARCHAR(80)
);

CREATE TABLE [FiscalYearsBackUp]
(
	[FiscalYearsBackUpId]  INT          NOT NULL IDENTITY (117,1),
	[BFY]                  NVARCHAR(80) NOT NULL,
	[EFY]                  NVARCHAR(80),
	[StartDate]            NVARCHAR(80),
	[ColumbusDay]          DATETIME,
	[VeteransDay]          DATETIME,
	[ThanksgivingDay]      DATETIME,
	[ChristmasDay]         DATETIME,
	[NewYearsDay]          DATETIME,
	[MartinLutherKingsDay] DATETIME,
	[WashingtonsDay]       DATETIME,
	[MemorialDay]          DATETIME,
	[JuneteenthDay]        DATETIME,
	[IndependenceDay]      DATETIME,
	[LaborDay]             DATETIME,
	[ExpiringYear]         NVARCHAR(80),
	[ExpirationDate]       NVARCHAR(80),
	[WorkDays]             FLOAT,
	[WeekDays]             FLOAT,
	[WeekEnds]             FLOAT,
	[EndDate]              NVARCHAR(80),
	[Availability]         NVARCHAR(80)
);

CREATE TABLE [FullTimeEquivalents]
(
	[FullTimeEquivialentsId] INT NOT NULL IDENTITY (14572,1),
	[OperatingPlansId]       INT,
	[RpioCode]               NVARCHAR(80),
	[RpioName]               NVARCHAR(80),
	[BFY]                    NVARCHAR(80),
	[EFY]                    NVARCHAR(80),
	[AhCode]                 NVARCHAR(80),
	[FundCode]               NVARCHAR(80),
	[OrgCode]                NVARCHAR(80),
	[AccountCode]            NVARCHAR(80),
	[RcCode]                 NVARCHAR(80),
	[BocCode]                NVARCHAR(80),
	[BocName]                NVARCHAR(80),
	[Amount]                 DECIMAL(18, 0),
	[ITProjectCode]          NVARCHAR(80),
	[ProjectCode]            NVARCHAR(80),
	[ProjectName]            NVARCHAR(80),
	[NpmCode]                NVARCHAR(80),
	[ProjectTypeName]        NVARCHAR(80),
	[ProjectTypeCode]        NVARCHAR(80),
	[ProgramProjectCode]     NVARCHAR(80),
	[ProgramAreaCode]        NVARCHAR(80),
	[NpmName]                NVARCHAR(80),
	[AhName]                 NVARCHAR(80),
	[FundName]               NVARCHAR(80),
	[OrgName]                NVARCHAR(80),
	[RcName]                 NVARCHAR(80),
	[ProgramProjectName]     NVARCHAR(80),
	[ActivityCode]           NVARCHAR(80),
	[ActivityName]           NVARCHAR(80),
	[LocalCode]              NVARCHAR(80),
	[LocalCodeName]          NVARCHAR(80),
	[ProgramAreaName]        NVARCHAR(80),
	[CostAreaCode]           NVARCHAR(80),
	[CostAreaName]           NVARCHAR(80),
	[alCode]                 NVARCHAR(80),
	[alName]                 NVARCHAR(80),
	[ObjectiveCode]          NVARCHAR(80),
	[ObjectiveName]          NVARCHAR(80)
);

CREATE TABLE [Funds]
(
	[FundsId]                       INT NOT NULL IDENTITY (1,1),
	[BFY]                           NVARCHAR(80),
	[EFY]                           NVARCHAR(80),
	[Code]                          NVARCHAR(80),
	[Name]                          NVARCHAR(80),
	[ShortName]                     NVARCHAR(80),
	[Status]                        NVARCHAR(80),
	[StartDate]                     NVARCHAR(80),
	[EndDate]                       NVARCHAR(80),
	[SubLevelPrefix]                NVARCHAR(80),
	[AllocationTransferAgency]      NVARCHAR(80),
	[AgencyIdentifier]              NVARCHAR(80),
	[BeginningPeriodOfAvailability] NVARCHAR(80),
	[EndingPeriodOfAvailability]    NVARCHAR(80),
	[MultiyearIndicator]            NVARCHAR(80),
	[MainAccount]                   NVARCHAR(80),
	[SubAccount]                    NVARCHAR(80),
	[FundCategory]                  NVARCHAR(80),
	[AppropriationCode]             NVARCHAR(80),
	[SubAppropriationCode]          NVARCHAR(80),
	[FundGroup]                     NVARCHAR(80),
	[NoYear]                        NVARCHAR(80),
	[Carryover]                     NVARCHAR(80),
	[CanceledYearSpendingAccount]   NVARCHAR(80),
	[ApplyAtAllLevels]              NVARCHAR(80),
	[BatsFund]                      NVARCHAR(80),
	[BatsEndDate]                   NVARCHAR(80),
	[BatsOptionId]                  NVARCHAR(80),
	[SecurityOrg]                   NVARCHAR(80),
	[BudgetAccountCode]             NVARCHAR(80),
	[BudgetAccountName]             NVARCHAR(80),
	[TreasuryAccountCode]           NVARCHAR(80),
	[TreasuryAccountName]           NVARCHAR(80),
	[ApportionmentAccountCode]      NVARCHAR(80)
);

CREATE TABLE [FundSymbols]
(
	[FundSymbolsId]            INT NOT NULL IDENTITY (14550,1),
	[BFY]                      NVARCHAR(80),
	[EFY]                      NVARCHAR(80),
	[FundCode]                 NVARCHAR(80),
	[FundName]                 NVARCHAR(80),
	[TreasuryAccountCode]      NVARCHAR(80),
	[TreasuryAccountName]      NVARCHAR(80),
	[OmbAccountCode]           NVARCHAR(80),
	[OmbAccountName]           NVARCHAR(80),
	[ApportionmentAccountCode] NVARCHAR(80)
);

CREATE TABLE [GeneralLedgerAccounts]
(
	[GeneralLedgerAccountsId] INT NOT NULL IDENTITY (1,1),
	[BFY]                     NVARCHAR(80),
	[Number]                  NVARCHAR(80),
	[Name]                    NVARCHAR(80),
	[ShortName]               NVARCHAR(80),
	[AccountClassification]   NVARCHAR(80),
	[NormalBalance]           NVARCHAR(80),
	[RealOrClosingAccount]    NVARCHAR(80),
	[CashAccount]             NVARCHAR(80),
	[SummaryAccount]          NVARCHAR(80),
	[ReportableAccount]       NVARCHAR(80),
	[CostAllocationIndicator] NVARCHAR(80),
	[FederalNonFederal]       NVARCHAR(80),
	[AttributeValue]          NVARCHAR(80),
	[Usage]                   NVARCHAR(80),
	[Deposit]                 NVARCHAR(80)
);

CREATE TABLE [GrowthRates]
(
	[GrowthRatesId]  INT NOT NULL,
	[RateId]         INT NOT NULL IDENTITY (25,1),
	[DESCRIPTION]    NVARCHAR(80),
	[BudgetYearRate] DECIMAL(18, 0),
	[OutYear1]       DECIMAL(18, 0),
	[OutYear2]       DECIMAL(18, 0),
	[OutYear3]       DECIMAL(18, 0),
	[OutYear4]       DECIMAL(18, 0),
	[OutYear5]       DECIMAL(18, 0),
	[OutYear6]       DECIMAL(18, 0),
	[OutYear7]       DECIMAL(18, 0),
	[OutYear8]       DECIMAL(18, 0),
	[OutYear9]       DECIMAL(18, 0),
	[Sort]           NVARCHAR(80)
);

CREATE TABLE [GsPayScales]
(
	[GsPayScalesId] INT NOT NULL IDENTITY (826,1),
	[LOCNAME]       NVARCHAR(80),
	[GRADE]         FLOAT,
	[ANNUAL1]       FLOAT,
	[HOURLY1]       NVARCHAR(80),
	[OVERTIME1]     NVARCHAR(80),
	[ANNUAL2]       FLOAT,
	[HOURLY2]       NVARCHAR(80),
	[OVERTIME2]     NVARCHAR(80),
	[ANNUAL3]       FLOAT,
	[HOURLY3]       NVARCHAR(80),
	[OVERTIME3]     NVARCHAR(80),
	[ANNUAL4]       FLOAT,
	[HOURLY4]       NVARCHAR(80),
	[OVERTIME4]     NVARCHAR(80),
	[ANNUAL5]       FLOAT,
	[HOURLY5]       NVARCHAR(80),
	[OVERTIME5]     NVARCHAR(80),
	[ANNUAL6]       FLOAT,
	[HOURLY6]       NVARCHAR(80),
	[OVERTIME6]     NVARCHAR(80),
	[ANNUAL7]       FLOAT,
	[HOURLY7]       NVARCHAR(80),
	[OVERTIME7]     NVARCHAR(80),
	[ANNUAL8]       FLOAT,
	[HOURLY8]       NVARCHAR(80),
	[OVERTIME8]     NVARCHAR(80),
	[ANNUAL9]       FLOAT,
	[HOURLY9]       NVARCHAR(80),
	[OVERTIME9]     NVARCHAR(80),
	[ANNUAL10]      FLOAT,
	[HOURLY10]      NVARCHAR(80),
	[OVERTIME10]    NVARCHAR(80)
);

CREATE TABLE [HeadquartersAuthority]
(
	[HeadquartersAuthorityId] INT NOT NULL IDENTITY (358600,1),
	[AllocationsId]           INT NOT NULL,
	[StatusOfFundsId]         INT NOT NULL,
	[BFY]                     NVARCHAR(80),
	[EFY]                     NVARCHAR(80),
	[RpioCode]                NVARCHAR(80),
	[RpioName]                NVARCHAR(80),
	[BudgetLevel]             NVARCHAR(80),
	[AhCode]                  NVARCHAR(80),
	[AhName]                  NVARCHAR(80),
	[FundCode]                NVARCHAR(80),
	[FundName]                NVARCHAR(80),
	[OrgCode]                 NVARCHAR(80),
	[OrgName]                 NVARCHAR(80),
	[AccountCode]             NVARCHAR(80),
	[RcCode]                  NVARCHAR(80),
	[RcName]                  NVARCHAR(80),
	[BocCode]                 NVARCHAR(80),
	[BocName]                 NVARCHAR(80),
	[Amount]                  DECIMAL(18, 0),
	[ProgramProjectCode]      NVARCHAR(80),
	[ProgramProjectName]      NVARCHAR(80),
	[ProgramAreaCode]         NVARCHAR(80),
	[ProgramAreaName]         NVARCHAR(80),
	[NpmCode]                 NVARCHAR(80),
	[NpmName]                 NVARCHAR(80)
);

CREATE TABLE [HeadquartersOffices]
(
	[HeadquartersOfficesId]   INT NOT NULL IDENTITY (14,1),
	[ResourcePlanninfficesId] INT,
	[Code]                    NVARCHAR(80),
	[Name]                    NVARCHAR(80)
);

CREATE TABLE [HumanResourceOrganizations]
(
	[HumanResourceOrganizationsId] INT NOT NULL IDENTITY (885,1),
	[Code]                         NVARCHAR(80),
	[Name]                         NVARCHAR(80)
);

CREATE TABLE [Images]
(
	[ImagesId]      INT NOT NULL IDENTITY (159,1),
	[FileName]      NVARCHAR(80),
	[FilePath]      NVARCHAR(80),
	[FileExtension] NVARCHAR(80),
	[ImageFile]     IMAGE,
	[Attachments]   NVARCHAR(80)
);

CREATE TABLE [InflationReductionActCarryoverEstimates]
(
	[InflationReductionActCarryoverEstimatesId] INT NOT NULL IDENTITY (1,1),
	[BFY]                                       NVARCHAR(80),
	[EFY]                                       NVARCHAR(80),
	[FundCode]                                  NVARCHAR(80),
	[FundName]                                  NVARCHAR(80),
	[TreasuryAccountCode]                       NVARCHAR(80),
	[RpioCode]                                  NVARCHAR(80),
	[RpioName]                                  NVARCHAR(80),
	[Amount]                                    FLOAT,
	[OpenCommitments]                           FLOAT,
	[Obligations]                               FLOAT,
	[Available]                                 FLOAT,
	[Estimate]                                  FLOAT
);

CREATE TABLE [InfrastructureAccounts]
(
	[InfrastructureAccountsId] INT NOT NULL IDENTITY (121,1),
	[StrategicPlan]            NVARCHAR(80),
	[BFY]                      NVARCHAR(80),
	[EFY]                      NVARCHAR(80),
	[AccountCode]              NVARCHAR(80),
	[alCode]                   NVARCHAR(80),
	[ObjectiveCode]            NVARCHAR(80),
	[NpmCode]                  NVARCHAR(80),
	[NpmName]                  NVARCHAR(80),
	[ProgramProjectCode]       NVARCHAR(80),
	[ProgramProjectName]       NVARCHAR(80),
	[ActivityCode]             NVARCHAR(80),
	[ActivityName]             NVARCHAR(80),
	[ProgramAreaCode]          NVARCHAR(80),
	[ProgramAreaName]          NVARCHAR(80),
	[ProgramName]              NVARCHAR(80),
	[ProgramDescription]       NVARCHAR(80)
);

CREATE TABLE [JobsActCarryoverEstimates]
(
	[CarryoverEstimatesId] INT NOT NULL IDENTITY (162,1),
	[BFY]                  NVARCHAR(80),
	[EFY]                  NVARCHAR(80),
	[FundCode]             NVARCHAR(80),
	[FundName]             NVARCHAR(80),
	[TreasuryAccountCode]  NVARCHAR(80),
	[RpioCode]             NVARCHAR(80),
	[RpioName]             NVARCHAR(80),
	[Amount]               DECIMAL(18, 0),
	[OpenCommitments]      DECIMAL(18, 0),
	[Obligations]          DECIMAL(18, 0),
	[Available]            DECIMAL(18, 0),
	[Estimate]             DECIMAL(18, 0)
);

CREATE TABLE [LedgerAccounts]
(
	[LedgerAccountsId] INT NOT NULL IDENTITY (388702,1),
	[BFY]              NVARCHAR(80),
	[EFY]              NVARCHAR(80),
	[FundCode]         NVARCHAR(80),
	[FundName]         NVARCHAR(80),
	[TreasurySymbol]   NVARCHAR(80),
	[AccountNumber]    NVARCHAR(80),
	[AccountName]      NVARCHAR(80),
	[BeginningBalance] DECIMAL(18, 0),
	[CreditBalance]    DECIMAL(18, 0),
	[DebitBalance]     DECIMAL(18, 0),
	[ClosingAmount]    DECIMAL(18, 0)
);

CREATE TABLE [Messages]
(
	[MessagesId] INT NOT NULL IDENTITY (14,1),
	[Message]    NVARCHAR(80),
	[Type]       NVARCHAR(80),
	[Form]       NVARCHAR(80)
);

CREATE TABLE [MonthlyActuals]
(
	[MonthlyActualsId]     INT NOT NULL IDENTITY (1,1),
	[BFY]                  NVARCHAR(80),
	[EFY]                  NVARCHAR(80),
	[FundCode]             NVARCHAR(80),
	[FundName]             NVARCHAR(80),
	[AppropriationCode]    NVARCHAR(80),
	[AppropriationName]    NVARCHAR(80),
	[SubAppropriationCode] NVARCHAR(80),
	[SubAppropriationName] NVARCHAR(80),
	[RpioCode]             NVARCHAR(80),
	[RpioName]             NVARCHAR(80),
	[AhCode]               NVARCHAR(80),
	[AhName]               NVARCHAR(80),
	[OrgCode]              NVARCHAR(80),
	[OrgName]              NVARCHAR(80),
	[RpioActivityCode]     NVARCHAR(80),
	[AccountCode]          NVARCHAR(80),
	[ProgramProjectCode]   NVARCHAR(80),
	[ProgramProjectName]   NVARCHAR(80),
	[BocCode]              NVARCHAR(80),
	[BocName]              NVARCHAR(80),
	[NetOutlays]           FLOAT,
	[GrossOutlays]         FLOAT,
	[Obligations]          FLOAT,
	[TreasuryAccountCode]  NVARCHAR(80),
	[TreasuryAccountName]  NVARCHAR(80),
	[BudgetAccountCode]    NVARCHAR(80),
	[BudgetAccountName]    NVARCHAR(80)
);

CREATE TABLE [MonthlyLedgerAccountBalances]
(
	[MonthlyLedgerAccountBalancesId] INT NOT NULL IDENTITY (109254,1),
	[FiscalYear]                     NVARCHAR(80),
	[BFY]                            NVARCHAR(80),
	[EFY]                            NVARCHAR(80),
	[FundCode]                       NVARCHAR(80),
	[FundName]                       NVARCHAR(80),
	[LedgerAccount]                  NVARCHAR(80),
	[LedgerName]                     NVARCHAR(80),
	[ApportionmentAccountCode]       NVARCHAR(80),
	[TreasurySymbol]                 NVARCHAR(80),
	[TreasurySymbolName]             NVARCHAR(80),
	[BudgetAccountCode]              NVARCHAR(80),
	[BudgetAccountName]              NVARCHAR(80),
	[FiscalMonth]                    NVARCHAR(80),
	[CreditBalance]                  DECIMAL(18, 0),
	[DebitBalance]                   DECIMAL(18, 0),
	[YearToDateAmount]               DECIMAL(18, 0)
);

CREATE TABLE [MonthlyOutlays]
(
	[MonthlyOutlaysId]    INT NOT NULL IDENTITY (1305,1),
	[FiscalYear]          NVARCHAR(80),
	[LineNumber]          NVARCHAR(80),
	[LineTitle]           NVARCHAR(80),
	[TaxationCode]        NVARCHAR(80),
	[TreasuryAgencyCode]  NVARCHAR(80),
	[TreasuryAccountCode] NVARCHAR(80),
	[SubAccount]          NVARCHAR(80),
	[BFY]                 NVARCHAR(80),
	[EFY]                 NVARCHAR(80),
	[OmbAgencyCode]       NVARCHAR(80),
	[OmbBureauCode]       NVARCHAR(80),
	[OmbAccountCode]      NVARCHAR(80),
	[AgencySequence]      NVARCHAR(80),
	[BureauSequence]      NVARCHAR(80),
	[AccountSequence]     NVARCHAR(80),
	[AgencyTitle]         NVARCHAR(80),
	[BureauTitle]         NVARCHAR(80),
	[OmbAccountName]      NVARCHAR(80),
	[TreasuryAccountName] NVARCHAR(80),
	[October]             DECIMAL(18, 0),
	[November]            DECIMAL(18, 0),
	[December]            DECIMAL(18, 0),
	[January]             DECIMAL(18, 0),
	[Feburary]            DECIMAL(18, 0),
	[March]               DECIMAL(18, 0),
	[April]               DECIMAL(18, 0),
	[May]                 DECIMAL(18, 0),
	[June]                DECIMAL(18, 0),
	[July]                DECIMAL(18, 0),
	[August]              DECIMAL(18, 0),
	[September]           DECIMAL(18, 0)
);

CREATE TABLE [NationalPrograms]
(
	[NationalProgramsId] INT           NOT NULL,
	[Code]               NVARCHAR(255) NOT NULL,
	[Name]               NVARCHAR(255),
	[RpioCode]           NVARCHAR(255),
	[Title]              NVARCHAR(255)
);

CREATE TABLE [ObjectClassOutlays]
(
	[ObjectClassOutlaysId]    INT NOT NULL IDENTITY (148,1),
	[ReportYear]              NVARCHAR(80),
	[OmbAgencyCode]           NVARCHAR(80),
	[OmbAgencyName]           NVARCHAR(80),
	[OmbBureauCode]           NVARCHAR(80),
	[OmbBureauName]           NVARCHAR(80),
	[OmbAccountCode]          NVARCHAR(80),
	[OmbAccountName]          NVARCHAR(80),
	[ObligationType]          NVARCHAR(80),
	[DirectReimbursableTitle] NVARCHAR(80),
	[ObjectClassGroupNumber]  NVARCHAR(80),
	[ObjectClassGroupName]    NVARCHAR(80),
	[BocCode]                 NVARCHAR(80),
	[BocName]                 NVARCHAR(80),
	[FinanceObjectClass]      NVARCHAR(255),
	[PriorYear]               DECIMAL(18, 0),
	[CurrentYear]             DECIMAL(18, 0),
	[BudgetYear]              DECIMAL(18, 0)
);

CREATE TABLE [Objectives]
(
	[ObjectivesId] INT NOT NULL IDENTITY (11,1),
	[Code]         NVARCHAR(80),
	[Name]         NVARCHAR(80),
	[Title]        NVARCHAR(80)
);

CREATE TABLE [ObligationActivity]
(
	[ObligationActivityId]    INT NOT NULL IDENTITY (1,1),
	[BFY]                     NVARCHAR(80),
	[EFY]                     NVARCHAR(80),
	[FundCode]                NVARCHAR(80),
	[FundName]                NVARCHAR(80),
	[TreasuryAccountCode]     NVARCHAR(80),
	[BudgetAccountCode]       NVARCHAR(80),
	[RpioCode]                NVARCHAR(80),
	[RpioName]                NVARCHAR(80),
	[AhCode]                  NVARCHAR(80),
	[AhName]                  NVARCHAR(80),
	[OrgCode]                 NVARCHAR(80),
	[OrgName]                 NVARCHAR(80),
	[AccountCode]             NVARCHAR(80),
	[ProgramProjectName]      NVARCHAR(80),
	[BocCode]                 NVARCHAR(80),
	[BocName]                 NVARCHAR(80),
	[FocCode]                 NVARCHAR(80),
	[FocName]                 NVARCHAR(80),
	[DocumentType]            NVARCHAR(80),
	[DocumentNumber]          NVARCHAR(80),
	[ProcessedDate]           DATETIME,
	[OpenCommitments]         FLOAT,
	[Obligations]             FLOAT,
	[Used]                    FLOAT,
	[UnliquidatedObligations] FLOAT,
	[Outlays]                 FLOAT
);

CREATE TABLE [Obligations]
(
	[ObligationsId]         INT NOT NULL IDENTITY (2,1),
	[BFY]                   NVARCHAR(80),
	[EFY]                   NVARCHAR(80),
	[RpioCode]              NVARCHAR(80),
	[RpioName]              NVARCHAR(80),
	[AhCode]                NVARCHAR(80),
	[AhName]                NVARCHAR(80),
	[FundCode]              NVARCHAR(80),
	[FundName]              NVARCHAR(80),
	[OrgCode]               NVARCHAR(80),
	[OrgName]               NVARCHAR(80),
	[AccountCode]           NVARCHAR(80),
	[ProgramProjectCode]    NVARCHAR(80),
	[ProgramProjectName]    NVARCHAR(80),
	[RcCode]                NVARCHAR(80),
	[RcName]                NVARCHAR(80),
	[DocumentType]          NVARCHAR(80),
	[DocumentNumber]        NVARCHAR(80),
	[DocumentControlNumber] NVARCHAR(80),
	[TreasurySymbol]        NVARCHAR(80),
	[OmbAccountCode]        NVARCHAR(80),
	[OmbAccountName]        NVARCHAR(80),
	[ProcessedDate]         DATETIME,
	[LastActivityDate]      DATETIME,
	[Age]                   DECIMAL(18, 0),
	[BocCode]               NVARCHAR(80),
	[BocName]               NVARCHAR(80),
	[FocCode]               NVARCHAR(80),
	[FocName]               NVARCHAR(80),
	[NpmCode]               NVARCHAR(80),
	[NpmName]               NVARCHAR(80),
	[VendorCode]            NVARCHAR(80),
	[VendorName]            NVARCHAR(80),
	[OpenCommitments]       DECIMAL(18, 0),
	[Obligations]           DECIMAL(18, 0),
	[ULO]                   DECIMAL(18, 0),
	[Expenditures]          DECIMAL(18, 0)
);

CREATE TABLE [OpenCommitments]
(
	[OpenCommitmentsId]     INT NOT NULL IDENTITY (69561,1),
	[ObligationsId]         INT,
	[BFY]                   NVARCHAR(80),
	[EFY]                   NVARCHAR(80),
	[RpioCode]              NVARCHAR(80),
	[RpioName]              NVARCHAR(80),
	[AhCode]                NVARCHAR(80),
	[AhName]                NVARCHAR(80),
	[FundCode]              NVARCHAR(80),
	[FundName]              NVARCHAR(80),
	[OrgCode]               NVARCHAR(80),
	[OrgName]               NVARCHAR(80),
	[AccountCode]           NVARCHAR(80),
	[ProgramProjectCode]    NVARCHAR(80),
	[ProgramProjectName]    NVARCHAR(80),
	[RcCode]                NVARCHAR(80),
	[RcName]                NVARCHAR(80),
	[DocumentType]          NVARCHAR(80),
	[DocumentNumber]        NVARCHAR(80),
	[DocumentControlNumber] NVARCHAR(80),
	[TreasurySymbol]        NVARCHAR(80),
	[OmbAccountCode]        NVARCHAR(80),
	[OmbAccountName]        NVARCHAR(80),
	[ProcessedDate]         DATETIME,
	[LastActivityDate]      DATETIME,
	[Age]                   NVARCHAR(80),
	[BocCode]               NVARCHAR(80),
	[BocName]               NVARCHAR(80),
	[FocCode]               NVARCHAR(80),
	[FocName]               NVARCHAR(80),
	[NpmCode]               NVARCHAR(80),
	[NpmName]               NVARCHAR(80),
	[VendorCode]            NVARCHAR(80),
	[VendorName]            NVARCHAR(80),
	[Amount]                DECIMAL(18, 0)
);

CREATE TABLE [OperatingPlans]
(
	[OperatingPlansId]    INT NOT NULL IDENTITY (1,1),
	[BFY]                 NVARCHAR(80),
	[EFY]                 NVARCHAR(80),
	[FundCode]            NVARCHAR(80),
	[RpioCode]            NVARCHAR(80),
	[OrgCode]             NVARCHAR(80),
	[AhCode]              NVARCHAR(80),
	[AccountCode]         NVARCHAR(80),
	[BocCode]             NVARCHAR(80),
	[BocName]             NVARCHAR(80),
	[Amount]              DECIMAL(18, 0),
	[NpmCode]             NVARCHAR(80),
	[ProgramProjectCode]  NVARCHAR(80),
	[ProgramAreaCode]     NVARCHAR(80),
	[NpmName]             NVARCHAR(80),
	[AhName]              NVARCHAR(80),
	[FundName]            NVARCHAR(80),
	[RpioName]            NVARCHAR(80),
	[OrgName]             NVARCHAR(80),
	[ProgramProjectName]  NVARCHAR(80),
	[ActivityCode]        NVARCHAR(80),
	[ActivityName]        NVARCHAR(80),
	[ProgramAreaName]     NVARCHAR(80),
	[ObjectiveCode]       NVARCHAR(80),
	[ObjectiveName]       NVARCHAR(80),
	[TreasuryAccountCode] NVARCHAR(80),
	[TreasuryAccountName] NVARCHAR(80),
	[BudgetAccountCode]   NVARCHAR(80),
	[BudgetAccountName]   NVARCHAR(80)
);

CREATE TABLE [OperatingPlanUpdates]
(
	[OperatingPlanUpdatesId] INT NOT NULL IDENTITY (2,1),
	[OppId]                  INT,
	[RPIO]                   NVARCHAR(80),
	[BFY]                    NVARCHAR(80),
	[BudgetLevel]            NVARCHAR(80),
	[AhCode]                 NVARCHAR(80),
	[FundCode]               NVARCHAR(80),
	[OrgCode]                NVARCHAR(80),
	[AccountCode]            NVARCHAR(80),
	[BocCode]                NVARCHAR(80),
	[BocName]                NVARCHAR(80),
	[RcCode]                 NVARCHAR(80),
	[Amount]                 DECIMAL(18, 0),
	[NpmCode]                NVARCHAR(80),
	[ProgramProjectCode]     NVARCHAR(80),
	[ProgramAreaCode]        NVARCHAR(80),
	[NpmName]                NVARCHAR(80),
	[AhName]                 NVARCHAR(80),
	[FundName]               NVARCHAR(80),
	[OrgName]                NVARCHAR(80),
	[ActivityCode]           NVARCHAR(80),
	[ActivityName]           NVARCHAR(80),
	[DivisionName]           NVARCHAR(80),
	[ProgramProjectName]     NVARCHAR(80),
	[ProgramAreaName]        NVARCHAR(80),
	[alCode]                 NVARCHAR(80),
	[alName]                 NVARCHAR(80),
	[ObjectiveCode]          NVARCHAR(80),
	[ObjectiveName]          NVARCHAR(80)
);

CREATE TABLE [Organizations]
(
	[OrganizationsId] INT NOT NULL IDENTITY (2,1),
	[BFY]             NVARCHAR(80),
	[Code]            NVARCHAR(80),
	[PreventNewUse]   NVARCHAR(80),
	[Name]            NVARCHAR(80),
	[Status]          NVARCHAR(80),
	[SecurityOrg]     NVARCHAR(80),
	[Usage]           NVARCHAR(80),
	[UseAsCostOrg]    NVARCHAR(80),
	[SubCodeRequired] NVARCHAR(80),
	[RpioCode]        NVARCHAR(80),
	[AhCode]          NVARCHAR(80),
	[RcCode]          NVARCHAR(80),
	[SubRcCode]       NVARCHAR(80),
	[Description]     NVARCHAR(80)
);

CREATE TABLE [PayPeriods]
(
	[PayPeriodsId] INT NOT NULL IDENTITY (203,1),
	[Period]       NVARCHAR(80),
	[PayPeriod]    NVARCHAR(80),
	[StartDate]    DATETIME,
	[EndDate]      DATETIME
);

CREATE TABLE [PayrollActivity]
(
	[PayrollActivityId]  INT NOT NULL IDENTITY (2,1),
	[BFY]                NVARCHAR(80),
	[EFY]                NVARCHAR(80),
	[RpioCode]           NVARCHAR(80),
	[RpioName]           NVARCHAR(80),
	[FundCode]           NVARCHAR(80),
	[FundName]           NVARCHAR(80),
	[AhCode]             NVARCHAR(80),
	[AhName]             NVARCHAR(80),
	[RcCode]             NVARCHAR(80),
	[RcName]             NVARCHAR(80),
	[SubRcCode]          NVARCHAR(80),
	[SubRcName]          NVARCHAR(80),
	[AccountCode]        NVARCHAR(80),
	[ProgramProjectCode] NVARCHAR(80),
	[ProgramProjectName] NVARCHAR(80),
	[ProgramAreaCode]    NVARCHAR(80),
	[ProgramAreaName]    NVARCHAR(80),
	[NpmCode]            NVARCHAR(80),
	[NpmName]            NVARCHAR(80),
	[FocCode]            NVARCHAR(80),
	[FocName]            NVARCHAR(80),
	[HrOrgCode]          NVARCHAR(80),
	[HrOrgName]          NVARCHAR(80),
	[WorkCode]           NVARCHAR(80),
	[WorkCodeName]       NVARCHAR(80),
	[PayPeriod]          NVARCHAR(80),
	[StartDate]          DATETIME,
	[EndDate]            DATETIME,
	[CheckDate]          DATETIME,
	[Amount]             DECIMAL(18, 0),
	[Hours]              DECIMAL(18, 0),
	[BasePaid]           DECIMAL(18, 0),
	[BaseHours]          DECIMAL(18, 0),
	[Benefits]           DECIMAL(18, 0),
	[OvertimePaid]       DECIMAL(18, 0),
	[OvertimeHours]      DECIMAL(18, 0)
);

CREATE TABLE [PayrollAuthority]
(
	[PayrollAuthorityId] INT NOT NULL IDENTITY (83105,1),
	[AllocationsId]      INT,
	[StatusOfFundsId]    INT,
	[BFY]                NVARCHAR(80),
	[EFY]                NVARCHAR(80),
	[RpioCode]           NVARCHAR(80),
	[RpioName]           NVARCHAR(80),
	[BudgetLevel]        NVARCHAR(80),
	[AhCode]             NVARCHAR(80),
	[AhName]             NVARCHAR(80),
	[FundCode]           NVARCHAR(80),
	[FundName]           NVARCHAR(80),
	[OrgCode]            NVARCHAR(80),
	[OrgName]            NVARCHAR(80),
	[AccountCode]        NVARCHAR(80),
	[RcCode]             NVARCHAR(80),
	[RcName]             NVARCHAR(80),
	[BocCode]            NVARCHAR(80),
	[BocName]            NVARCHAR(80),
	[Amount]             DECIMAL(18, 0),
	[ProgramProjectCode] NVARCHAR(80),
	[ProgramProjectName] NVARCHAR(80),
	[ProgramAreaCode]    NVARCHAR(80),
	[ProgramAreaName]    NVARCHAR(80),
	[NpmCode]            NVARCHAR(80),
	[NpmName]            NVARCHAR(80)
);

CREATE TABLE [PayrollCostCodes]
(
	[PayrollCostCodesId] INT NOT NULL IDENTITY (21503,1),
	[RpioCode]           NVARCHAR(80),
	[RpioName]           NVARCHAR(80),
	[AhCode]             NVARCHAR(80),
	[AhName]             NVARCHAR(80),
	[RcCode]             NVARCHAR(80),
	[RcName]             NVARCHAR(80),
	[SubRcCode]          NVARCHAR(80),
	[SubRcName]          NVARCHAR(80),
	[HrOrgCode]          NVARCHAR(80),
	[HrOrgName]          NVARCHAR(80),
	[WorkCode]           NVARCHAR(80),
	[WorkCodeName]       NVARCHAR(80)
);

CREATE TABLE [PayrollRequests]
(
	[PayrollRequestsId]   INT NOT NULL IDENTITY (16,1),
	[ControlTeamAnalyst]  NVARCHAR(80),
	[RpioCode]            NVARCHAR(80),
	[DocumentTitle]       NVARCHAR(80),
	[Amount]              DECIMAL(18, 0),
	[FundCode]            NVARCHAR(80),
	[Status]              NVARCHAR(80),
	[OriginalRequestDate] DATETIME,
	[LastActivityDate]    DATETIME,
	[BFS]                 NVARCHAR(80),
	[Comments]            NVARCHAR(80),
	[RequestDocument]     NTEXT,
	[Duration]            INT
);

CREATE TABLE [ProgramAreas]
(
	[ProgramAreasId] INT          NOT NULL IDENTITY (1,1),
	[Code]           NVARCHAR(80) NOT NULL,
	[Name]           NVARCHAR(80)
);

CREATE TABLE [ProgramFinancingSchedule]
(
	[ProgramFinancingScheduleId] INT NOT NULL IDENTITY (27245,1),
	[ReportYear]                 NVARCHAR(80),
	[TreasuryAgencyCode]         NVARCHAR(80),
	[TreasuryAccountCode]        NVARCHAR(80),
	[LedgerAccountCode]          NVARCHAR(80),
	[SectionNumber]              NVARCHAR(80),
	[SectionName]                NVARCHAR(80),
	[LineNumber]                 NVARCHAR(80),
	[LineDescription]            NVARCHAR(80),
	[OmbAgencyCode]              NVARCHAR(80),
	[OmbFundCode]                NVARCHAR(80),
	[OmbAccountTitle]            NVARCHAR(80),
	[AgencySequence]             NVARCHAR(80),
	[AccountSequence]            NVARCHAR(80),
	[FundName]                   NVARCHAR(80),
	[OriginalAmount]             DECIMAL(18, 0),
	[BudgetAmount]               DECIMAL(18, 0),
	[AgencyAmount]               DECIMAL(18, 0),
	[Amount]                     DECIMAL(18, 0),
	[AgencyName]                 NVARCHAR(80)
);

CREATE TABLE [ProgramProjectDescriptions]
(
	[ProgramProjectDescriptionsId] INT NOT NULL IDENTITY (192,1),
	[Code]                         NVARCHAR(80),
	[Name]                         NVARCHAR(80),
	[ProgramTitle]                 NVARCHAR(80),
	[Laws]                         NTEXT,
	[Description]                  NTEXT,
	[ProgramAreaCode]              NVARCHAR(80),
	[ProgramAreaName]              NVARCHAR(80)
);

CREATE TABLE [ProgramProjects]
(
	[ProgramProjectsId] INT NOT NULL IDENTITY (192,1),
	[Code]              NVARCHAR(80),
	[Name]              NVARCHAR(80),
	[ProgramAreaCode]   NVARCHAR(80),
	[ProgramAreaName]   NVARCHAR(80)
);

CREATE TABLE [ProjectCostCodes]
(
	[ProjectCostCodesId] INT NOT NULL IDENTITY (400176,1),
	[BFY]                NVARCHAR(80),
	[RpioCode]           NVARCHAR(80),
	[RpioName]           NVARCHAR(80),
	[AhCode]             NVARCHAR(80),
	[AhName]             NVARCHAR(80),
	[FundCode]           NVARCHAR(80),
	[FundName]           NVARCHAR(80),
	[AccountCode]        NVARCHAR(80),
	[ProgramProjectName] NVARCHAR(80),
	[BocCode]            NVARCHAR(80),
	[BocName]            NVARCHAR(80),
	[OrgCode]            NVARCHAR(80),
	[OrgName]            NVARCHAR(80),
	[VendorCode]         NVARCHAR(80),
	[VendorName]         NVARCHAR(80)
);

CREATE TABLE [Projects]
(
	[ProjectsId] INT NOT NULL IDENTITY (148,1),
	[Code]       NVARCHAR(80),
	[Name]       NVARCHAR(80)
);

CREATE TABLE [Providers]
(
	[ProvidersId]   INT NOT NULL IDENTITY (10,1),
	[ProviderName]  NVARCHAR(80),
	[FileExtension] NVARCHAR(80),
	[Connection]    NVARCHAR(80),
	[Properties]    NVARCHAR(80)
);

CREATE TABLE [PublicLaws]
(
	[PublicLawsId] INT NOT NULL IDENTITY (5302,1),
	[LawNumber]    NVARCHAR(80),
	[BillTitle]    NVARCHAR(80),
	[EnactedDate]  DATETIME,
	[Congress]     NVARCHAR(80),
	[BFY]          NVARCHAR(80)
);

CREATE TABLE [QueryDefinitions]
(
	[QueryDefinitionsId] INT NOT NULL IDENTITY (9987,1),
	[Name]               NVARCHAR(80),
	[Type]               NVARCHAR(80)
);

CREATE TABLE [RecoveryAct]
(
	[RecoveryActId]      INT NOT NULL IDENTITY (464,1),
	[BFY]                NVARCHAR(80),
	[EFY]                NVARCHAR(80),
	[FundCode]           NVARCHAR(80),
	[FundName]           NVARCHAR(80),
	[RpioCode]           NVARCHAR(80),
	[RpioName]           NVARCHAR(80),
	[OrgCode]            NVARCHAR(80),
	[OrgName]            NVARCHAR(80),
	[AccountCode]        NVARCHAR(80),
	[ProgramProjectName] NVARCHAR(80),
	[BocCode]            NVARCHAR(80),
	[BocName]            NVARCHAR(80),
	[Amount]             DECIMAL(18, 0)
);

CREATE TABLE [ReferenceTables]
(
	[ReferenceTablesId] INT NOT NULL IDENTITY (401,1),
	[TableName]         NVARCHAR(80),
	[Type]              NVARCHAR(80)
);

CREATE TABLE [RegionalAuthority]
(
	[RegionalAuthorityId] INT NOT NULL IDENTITY (743134,1),
	[AllocationsId]       INT NOT NULL,
	[StatusOfFundsId]     INT NOT NULL,
	[BFY]                 NVARCHAR(80),
	[EFY]                 NVARCHAR(80),
	[RpioCode]            NVARCHAR(80),
	[RpioName]            NVARCHAR(80),
	[BudgetLevel]         NVARCHAR(80),
	[AhCode]              NVARCHAR(80),
	[AhName]              NVARCHAR(80),
	[FundCode]            NVARCHAR(80),
	[FundName]            NVARCHAR(80),
	[OrgCode]             NVARCHAR(80),
	[OrgName]             NVARCHAR(80),
	[AccountCode]         NVARCHAR(80),
	[RcCode]              NVARCHAR(80),
	[RcName]              NVARCHAR(80),
	[BocCode]             NVARCHAR(80),
	[BocName]             NVARCHAR(80),
	[Amount]              DECIMAL(18, 0),
	[ProgramProjectCode]  NVARCHAR(80),
	[ProgramProjectName]  NVARCHAR(80),
	[ProgramAreaCode]     NVARCHAR(80),
	[ProgramAreaName]     NVARCHAR(80),
	[NpmCode]             NVARCHAR(80),
	[NpmName]             NVARCHAR(80)
);

CREATE TABLE [RegionalOffices]
(
	[RegionalOfficesId]       INT NOT NULL IDENTITY (11,1),
	[ResourcePlanninfficesId] INT,
	[Code]                    NVARCHAR(80),
	[Name]                    NVARCHAR(80)
);

CREATE TABLE [ReimbursableAgreements]
(
	[ReimbursableAgreementsId] INT NOT NULL IDENTITY (143691,1),
	[RPIO]                     NVARCHAR(80),
	[BFY]                      NVARCHAR(80),
	[AgreementNumber]          NVARCHAR(80),
	[FundCode]                 NVARCHAR(80),
	[StartDate]                DATETIME,
	[EndDate]                  DATETIME,
	[RcCode]                   NVARCHAR(80),
	[RcName]                   NVARCHAR(80),
	[OrgCode]                  NVARCHAR(80),
	[SiteProjectCode]          NVARCHAR(80),
	[AccountCode]              NVARCHAR(80),
	[VendorCode]               NVARCHAR(80),
	[VendorName]               NVARCHAR(80),
	[Amount]                   DECIMAL(18, 0),
	[OpenCommitments]          DECIMAL(18, 0),
	[Obligations]              DECIMAL(18, 0),
	[ULO]                      DECIMAL(18, 0),
	[Available]                DECIMAL(18, 0)
);

CREATE TABLE [ReimbursableFunds]
(
	[ReimbursableFundsId]   INT NOT NULL IDENTITY (871310,1),
	[RpioCode]              NVARCHAR(80),
	[BFY]                   NVARCHAR(80),
	[FundCode]              NVARCHAR(80),
	[AccountCode]           NVARCHAR(80),
	[RcCode]                NVARCHAR(80),
	[RcName]                NVARCHAR(80),
	[BocCode]               NVARCHAR(80),
	[DocumentControlNumber] NVARCHAR(80),
	[AgreeementNumber]      NVARCHAR(80),
	[Amount]                DECIMAL(18, 0),
	[OpenCommitments]       DECIMAL(18, 0),
	[Obligations]           DECIMAL(18, 0),
	[ULO]                   DECIMAL(18, 0),
	[Available]             DECIMAL(18, 0)
);

CREATE TABLE [Reports]
(
	[ReportsId] INT NOT NULL IDENTITY (55,1),
	[Name]      NVARCHAR(80),
	[Title]     NVARCHAR(80)
);

CREATE TABLE [Reprogrammings]
(
	[ReprogrammingsId]    INT NOT NULL IDENTITY (538644,1),
	[DocPrefix]           NVARCHAR(80),
	[ReprogrammingNumber] NVARCHAR(80),
	[BFY]                 NVARCHAR(80),
	[RpioCode]            NVARCHAR(80),
	[RpioName]            NVARCHAR(80),
	[FundCode]            NVARCHAR(80),
	[FundName]            NVARCHAR(80),
	[ProcessedDate]       DATETIME,
	[DocType]             NVARCHAR(80),
	[AccountCode]         NVARCHAR(80),
	[ProgramProjectName]  NVARCHAR(80),
	[ProgramAreaCode]     NVARCHAR(80),
	[ProgramAreaName]     NVARCHAR(80),
	[FromTo]              NVARCHAR(80),
	[BocCode]             NVARCHAR(80),
	[BocName]             NVARCHAR(80),
	[Purpose]             NTEXT,
	[ExtendedPurpose]     NTEXT,
	[ResourceType]        NVARCHAR(80),
	[Amount]              DECIMAL(18, 0)
);

CREATE TABLE [ResourcePlanningOffices]
(
	[ResourcePlanninfficesId] INT NOT NULL IDENTITY (36,1),
	[Code]                    NVARCHAR(80),
	[Name]                    NVARCHAR(80)
);

CREATE TABLE [Resources]
(
	[ResourcesId]   INT NOT NULL IDENTITY (78,1),
	[FileName]      NVARCHAR(80),
	[FileType]      NVARCHAR(80),
	[FilePath]      NTEXT,
	[FileExtension] NVARCHAR(80)
);

CREATE TABLE [ResponsibilityCenters]
(
	[ResponsibilityCentersId] INT NOT NULL IDENTITY (1314,1),
	[Code]                    NVARCHAR(80),
	[Name]                    NVARCHAR(80),
	[Title]                   NVARCHAR(80)
);

CREATE TABLE [SchemaTypes]
(
	[SchemaTypesId] INT NOT NULL IDENTITY (46,1),
	[TypeName]      NVARCHAR(80),
	[Database]      NVARCHAR(80)
);

CREATE TABLE [SiteActivity]
(
	[SiteActivityId]        INT NOT NULL IDENTITY (266266,1),
	[BFY]                   NVARCHAR(80),
	[EFY]                   NVARCHAR(80),
	[RpioCode]              NVARCHAR(80),
	[RpioName]              NVARCHAR(80),
	[AhCode]                NVARCHAR(80),
	[FundCode]              NVARCHAR(80),
	[FundName]              NVARCHAR(80),
	[AccountCode]           NVARCHAR(80),
	[ProgramProjectCode]    NVARCHAR(80),
	[ProgramProjectName]    NVARCHAR(80),
	[BocCode]               NVARCHAR(80),
	[BocName]               NVARCHAR(80),
	[OrgCode]               NVARCHAR(80),
	[OrgName]               NVARCHAR(80),
	[FocCode]               NVARCHAR(80),
	[FocName]               NVARCHAR(80),
	[EpaSiteId]             NVARCHAR(80),
	[SiteProjectCode]       NVARCHAR(80),
	[SSID]                  NVARCHAR(80),
	[ActionCode]            NVARCHAR(80),
	[OperableUnit]          NVARCHAR(80),
	[SiteProjectName]       NVARCHAR(80),
	[State]                 NVARCHAR(80),
	[City]                  NVARCHAR(80),
	[CongressionalDistrict] NVARCHAR(80),
	[ProjectType]           NVARCHAR(80),
	[StartDate]             DATETIME,
	[EndDate]               DATETIME,
	[LastActivity]          DATETIME,
	[Requested]             DECIMAL(18, 0),
	[Accepted]              DECIMAL(18, 0),
	[Closed]                DECIMAL(18, 0),
	[Outstanding]           DECIMAL(18, 0),
	[Refunded]              DECIMAL(18, 0),
	[Reversal]              DECIMAL(18, 0)
);

CREATE TABLE [SiteProjectCodes]
(
	[SiteProjectCodesId]    INT NOT NULL IDENTITY (8988,1),
	[RpioCode]              NVARCHAR(80),
	[RpioName]              NVARCHAR(80),
	[State]                 NVARCHAR(80),
	[CongressionalDistrict] NVARCHAR(80),
	[EpaSiteId]             NVARCHAR(80),
	[SiteProjectName]       NVARCHAR(80),
	[SiteProjectCode]       NVARCHAR(80),
	[SSID]                  NVARCHAR(80),
	[ActionCode]            NVARCHAR(80),
	[OperableUnit]          NVARCHAR(80)
);

CREATE TABLE [SpecialAccounts]
(
	[SpecialAccountsId]    INT NOT NULL IDENTITY (957754,1),
	[BFY]                  NVARCHAR(80),
	[RpioCode]             NVARCHAR(80),
	[FundCode]             NVARCHAR(80),
	[SpecialAccountFund]   NVARCHAR(80),
	[SpecialAccountNumber] NVARCHAR(80),
	[SpecialAccountName]   NVARCHAR(80),
	[AccountStatus]        NVARCHAR(80),
	[NplStatusCode]        NVARCHAR(80),
	[NplStatusName]        NVARCHAR(80),
	[SiteId]               NVARCHAR(80),
	[CerclisId]            NVARCHAR(80),
	[SiteCode]             NVARCHAR(80),
	[SiteName]             NVARCHAR(80),
	[OperableUnit]         NVARCHAR(80),
	[PipelineCode]         NVARCHAR(80),
	[PipelineDescription]  NVARCHAR(80),
	[AccountCode]          NVARCHAR(80),
	[BocCode]              NVARCHAR(80),
	[BocName]              NVARCHAR(80),
	[TransactionType]      NVARCHAR(80),
	[TransactionTypeName]  NVARCHAR(80),
	[FocCode]              NVARCHAR(80),
	[FocName]              NVARCHAR(80),
	[TransactionDate]      DATETIME,
	[AvailableBalance]     DECIMAL(18, 0),
	[OpenCommitments]      DECIMAL(18, 0),
	[Obligations]          DECIMAL(18, 0),
	[ULO]                  DECIMAL(18, 0),
	[Disbursements]        DECIMAL(18, 0),
	[UnpaidBalances]       DECIMAL(18, 0),
	[Collections]          DECIMAL(18, 0),
	[CumulativeReceipts]   DECIMAL(18, 0)
);

CREATE TABLE [SpendingDocuments]
(
	[SpendingDocumentsId]    INT NOT NULL IDENTITY (1,1),
	[BFY]                    NVARCHAR(80),
	[EFY]                    NVARCHAR(80),
	[TreasurySymbol]         NVARCHAR(80),
	[RpioCode]               NVARCHAR(80),
	[RpioName]               NVARCHAR(80),
	[FundCode]               NVARCHAR(80),
	[FundName]               NVARCHAR(80),
	[AhCode]                 NVARCHAR(80),
	[AhName]                 NVARCHAR(80),
	[AccountCode]            NVARCHAR(80),
	[ActivityCode]           NVARCHAR(80),
	[ProgramProjectName]     NVARCHAR(80),
	[ProgramAreaCode]        NVARCHAR(80),
	[ProgramAreaName]        NVARCHAR(80),
	[PurchaseRequestNumber]  NVARCHAR(80),
	[DocumentType]           NVARCHAR(80),
	[DocumentControlNumber]  NVARCHAR(80),
	[BocCode]                NVARCHAR(80),
	[BocName]                NVARCHAR(80),
	[OriginalActionDate]     DATETIME,
	[LastActionDate]         DATETIME,
	[Commitments]            FLOAT,
	[Obligations]            FLOAT,
	[Deobligations]          FLOAT,
	[UnliqudatedObligations] FLOAT
);

CREATE TABLE [SpendingRates]
(
	[SpendingRatesId]      INT NOT NULL IDENTITY (107,1),
	[OmbAgencyCode]        NVARCHAR(80),
	[OmbAgencyName]        NVARCHAR(80),
	[OmbBureauCode]        NVARCHAR(80),
	[OmbBureauName]        NVARCHAR(80),
	[TreausuryAgencyCode]  NVARCHAR(80),
	[TreausuryAccountCode] NVARCHAR(80),
	[TreausuryAccountName] NVARCHAR(80),
	[AccountTitle]         NVARCHAR(80),
	[Subfunction]          NVARCHAR(80),
	[Line]                 NVARCHAR(80),
	[LineNumber]           NVARCHAR(80),
	[Catery]               NVARCHAR(80),
	[Subcatery]            NVARCHAR(80),
	[SubcateryName]        NVARCHAR(80),
	[AccountCode]          NVARCHAR(80),
	[Jurisdiction]         NVARCHAR(80),
	[YearOfAuthority]      NVARCHAR(80),
	[BudgetAuthority]      DECIMAL(18, 0),
	[OutYear1]             DECIMAL(18, 0),
	[OutYear2]             DECIMAL(18, 0),
	[OutYear3]             DECIMAL(18, 0),
	[OutYear4]             DECIMAL(18, 0),
	[OutYear5]             DECIMAL(18, 0),
	[OutYear6]             DECIMAL(18, 0),
	[OutYear7]             DECIMAL(18, 0),
	[OutYear8]             DECIMAL(18, 0),
	[OutYear9]             DECIMAL(18, 0),
	[OutYear10]            DECIMAL(18, 0),
	[OutYear11]            DECIMAL(18, 0),
	[TotalSpendout]        DECIMAL(18, 0)
);

CREATE TABLE [StateGrantObligations]
(
	[StateGrantObligationsId] INT NOT NULL IDENTITY (12833,1),
	[RpioCode]                NVARCHAR(80),
	[RpioName]                NVARCHAR(80),
	[FundCode]                NVARCHAR(80),
	[FundName]                NVARCHAR(80),
	[AhCode]                  NVARCHAR(80),
	[AhName]                  NVARCHAR(80),
	[OrgCode]                 NVARCHAR(80),
	[OrgName]                 NVARCHAR(80),
	[StateCode]               NVARCHAR(80),
	[StateName]               NVARCHAR(80),
	[AccountCode]             NVARCHAR(80),
	[ProgramProjectCode]      NVARCHAR(80),
	[ProgramProjectName]      NVARCHAR(80),
	[RcCode]                  NVARCHAR(80),
	[RcName]                  NVARCHAR(80),
	[BocCode]                 NVARCHAR(80),
	[BocName]                 NVARCHAR(80),
	[Amount]                  DECIMAL(18, 0)
);

CREATE TABLE [StateOrganizations]
(
	[StateOrganizationsId] INT NOT NULL IDENTITY (150,1),
	[Name]                 NVARCHAR(80),
	[Code]                 NVARCHAR(80),
	[OrgCode]              NVARCHAR(80),
	[RpioName]             NVARCHAR(80),
	[RpioCode]             NVARCHAR(80)
);

CREATE TABLE [StatusOfAmericanRescuePlanFunds]
(
	[AmericanRescuePlanId]    INT NOT NULL IDENTITY (1,1),
	[StatusOfFundsId]         INT,
	[BudgetLevel]             NVARCHAR(80),
	[BFY]                     NVARCHAR(80),
	[EFY]                     NVARCHAR(80),
	[FundCode]                NVARCHAR(80),
	[FundName]                NVARCHAR(80),
	[RpioCode]                NVARCHAR(80),
	[RpioName]                NVARCHAR(80),
	[AhCode]                  NVARCHAR(80),
	[AhName]                  NVARCHAR(80),
	[OrgCode]                 NVARCHAR(80),
	[OrgName]                 NVARCHAR(80),
	[AccountCode]             NVARCHAR(80),
	[BocCode]                 NVARCHAR(255),
	[BocName]                 NVARCHAR(80),
	[ProgramProjectCode]      NVARCHAR(80),
	[ProgramProjectName]      NVARCHAR(80),
	[ProgramAreaCode]         NVARCHAR(80),
	[ProgramAreaName]         NVARCHAR(80),
	[RcCode]                  NVARCHAR(80),
	[RcName]                  NVARCHAR(80),
	[LowerName]               NVARCHAR(80),
	[Amount]                  FLOAT,
	[Budgeted]                FLOAT,
	[Posted]                  FLOAT,
	[OpenCommitments]         FLOAT,
	[UnliquidatedObligations] FLOAT,
	[Expenditures]            FLOAT,
	[Obligations]             FLOAT,
	[Used]                    FLOAT,
	[Available]               FLOAT,
	[NpmCode]                 NVARCHAR(80),
	[NpmName]                 NVARCHAR(80),
	[TreasuryAccountCode]     NVARCHAR(80),
	[TreasuryAccountName]     NVARCHAR(80),
	[BudgetAccountCode]       NVARCHAR(80),
	[BudgetAccountName]       NVARCHAR(80)
);

CREATE TABLE [StatusOfAppropriations]
(
	[StatusOfAppropriationsId]         INT NOT NULL IDENTITY (51123,1),
	[BFY]                              NVARCHAR(80),
	[EFY]                              NVARCHAR(80),
	[BudgetLevel]                      NVARCHAR(80),
	[AppropriationFundCode]            NVARCHAR(80),
	[AppropriationFundName]            NVARCHAR(80),
	[Availability]                     NVARCHAR(80),
	[TreasurySymbol]                   NVARCHAR(80),
	[OmbAccountCode]                   NVARCHAR(80),
	[AppropriationCreationDate]        DATETIME,
	[AppropriationCode]                NVARCHAR(80),
	[SubAppropriationCode]             NVARCHAR(80),
	[AppropriationDescription]         NVARCHAR(80),
	[FundGroup]                        NVARCHAR(80),
	[FundGroupName]                    NVARCHAR(80),
	[DocumentType]                     NVARCHAR(80),
	[TransType]                        NVARCHAR(80),
	[ActualRecoveryTransType]          NVARCHAR(80),
	[CommitmentSpendingControlFlag]    NVARCHAR(80),
	[AgreementLimit]                   NVARCHAR(80),
	[EstimatedRecoveriesTransType]     NVARCHAR(80),
	[EstimatedReimbursmentsTransType]  NVARCHAR(80),
	[ExpenseSpendingControlFlag]       NVARCHAR(80),
	[ObligationSpendingControlFlag]    NVARCHAR(80),
	[PreCommitmentSpendingControlFlag] NVARCHAR(80),
	[PostedControlFlag]                NVARCHAR(80),
	[PostedFlag]                       NVARCHAR(80),
	[RecordCarryoverAtLowerLevel]      NVARCHAR(80),
	[ReimbursableSpendinption]         NVARCHAR(80),
	[RecoveriesOption]                 NVARCHAR(80),
	[RecoveriesSpendinption]           NVARCHAR(80),
	[OriginalBudgetedAmount]           DECIMAL(18, 0),
	[ApportionmentsPosted]             DECIMAL(18, 0),
	[TotalAuthority]                   DECIMAL(18, 0),
	[TotalBudgeted]                    DECIMAL(18, 0),
	[TotalPostedAmount]                DECIMAL(18, 0),
	[FundsWithdrawnPriorYearsAmount]   DECIMAL(18, 0),
	[FundingInAmount]                  DECIMAL(18, 0),
	[FundinutAmount]                   DECIMAL(18, 0),
	[TotalAccrualRecoveries]           DECIMAL(18, 0),
	[TotalActualReimbursements]        DECIMAL(18, 0),
	[TotalAgreementReimbursables]      DECIMAL(18, 0),
	[TotalCarriedForwardIn]            DECIMAL(18, 0),
	[TotalCarriedForwardOut]           DECIMAL(18, 0),
	[TotalCommitted]                   DECIMAL(18, 0),
	[TotalEstimatedRecoveries]         DECIMAL(18, 0),
	[TotalEstimatedReimbursements]     DECIMAL(18, 0),
	[TotalExpenses]                    DECIMAL(18, 0),
	[TotalExpenditureExpenses]         DECIMAL(18, 0),
	[TotalExpenseAccruals]             DECIMAL(18, 0),
	[TotalPreCommitments]              DECIMAL(18, 0),
	[UnliquidatedPreCommitments]       DECIMAL(18, 0),
	[TotalObligations]                 DECIMAL(18, 0),
	[ULO]                              DECIMAL(18, 0),
	[VoidedAmount]                     DECIMAL(18, 0),
	[TotalUsedAmount]                  DECIMAL(18, 0),
	[AvailableAmount]                  DECIMAL(18, 0)
);

CREATE TABLE [StatusOfFunds]
(
	[StatusOfFundsId]    INT          NOT NULL IDENTITY (16413,1),
	[BudgetLevel]        NVARCHAR(80),
	[BFY]                NVARCHAR(80),
	[EFY]                NVARCHAR(80),
	[RpioCode]           NVARCHAR(80),
	[RpioName]           NVARCHAR(80),
	[AhCode]             NVARCHAR(80),
	[AhName]             NVARCHAR(80),
	[FundCode]           NVARCHAR(80),
	[FundName]           NVARCHAR(80) NOT NULL,
	[OrgCode]            NVARCHAR(80),
	[OrgName]            NVARCHAR(80),
	[AccountCode]        NVARCHAR(80),
	[BocCode]            NVARCHAR(80),
	[BocName]            NVARCHAR(80),
	[ProgramProjectCode] NVARCHAR(80),
	[ProgramProjectName] NVARCHAR(80),
	[ProgramAreaCode]    NVARCHAR(80),
	[ProgramAreaName]    NVARCHAR(80),
	[RcCode]             NVARCHAR(80),
	[RcName]             NVARCHAR(80),
	[LowerName]          NVARCHAR(80),
	[Amount]             DECIMAL(18, 0),
	[Budgeted]           DECIMAL(18, 0),
	[Posted]             DECIMAL(18, 0),
	[OpenCommitments]    DECIMAL(18, 0),
	[ULO]                DECIMAL(18, 0),
	[Expenditures]       DECIMAL(18, 0),
	[Obligations]        DECIMAL(18, 0),
	[Used]               DECIMAL(18, 0),
	[Available]          DECIMAL(18, 0),
	[NpmCode]            NVARCHAR(80),
	[NpmName]            NVARCHAR(80)
);

CREATE TABLE [StatusOfInflationReductionActFunds]
(
	[StatusOfSupplementalFundingId] INT NOT NULL,
	[StatusOfFundsId]               INT,
	[BudgetLevel]                   NVARCHAR(80),
	[BFY]                           NVARCHAR(80),
	[EFY]                           NVARCHAR(80),
	[FundCode]                      NVARCHAR(80),
	[FundName]                      NVARCHAR(80),
	[RpioCode]                      NVARCHAR(80),
	[RpioName]                      NVARCHAR(80),
	[AhCode]                        NVARCHAR(80),
	[AhName]                        NVARCHAR(80),
	[OrgCode]                       NVARCHAR(80),
	[OrgName]                       NVARCHAR(80),
	[AccountCode]                   NVARCHAR(80),
	[BocCode]                       NVARCHAR(80),
	[BocName]                       NVARCHAR(80),
	[ProgramProjectCode]            NVARCHAR(80),
	[ProgramProjectName]            NVARCHAR(80),
	[ProgramAreaCode]               NVARCHAR(80),
	[ProgramAreaName]               NVARCHAR(80),
	[RcCode]                        NVARCHAR(80),
	[RcName]                        NVARCHAR(80),
	[LowerName]                     NVARCHAR(80),
	[Amount]                        FLOAT,
	[Budgeted]                      FLOAT,
	[Posted]                        FLOAT,
	[OpenCommitments]               FLOAT,
	[UnliquidatedObligations]       FLOAT,
	[Expenditures]                  FLOAT,
	[Obligations]                   FLOAT,
	[Used]                          FLOAT,
	[Available]                     FLOAT,
	[Balance]                       FLOAT,
	[NpmCode]                       NVARCHAR(80),
	[NpmName]                       NVARCHAR(80),
	[TreasuryAccountCode]           NVARCHAR(80),
	[TreasuryAccountName]           NVARCHAR(80),
	[BudgetAccountCode]             NVARCHAR(80),
	[BudgetAccountName]             NVARCHAR(80)
);

CREATE TABLE [StatusOfJobsActFunding]
(
	[StatusOfJobsActFundingId] INT NOT NULL IDENTITY (50369,1),
	[StatusOfFundsId]          INT,
	[BudgetLevel]              NVARCHAR(80),
	[BFY]                      NVARCHAR(80),
	[EFY]                      NVARCHAR(80),
	[RpioCode]                 NVARCHAR(80),
	[RpioName]                 NVARCHAR(80),
	[AhCode]                   NVARCHAR(80),
	[AhName]                   NVARCHAR(80),
	[FundCode]                 NVARCHAR(80),
	[FundName]                 NVARCHAR(80),
	[OrgCode]                  NVARCHAR(80),
	[OrgName]                  NVARCHAR(80),
	[AccountCode]              NVARCHAR(80),
	[BocCode]                  NVARCHAR(80),
	[BocName]                  NVARCHAR(80),
	[ProgramProjectCode]       NVARCHAR(80),
	[ProgramProjectName]       NVARCHAR(80),
	[ProgramAreaCode]          NVARCHAR(80),
	[ProgramAreaName]          NVARCHAR(80),
	[NpmCode]                  NVARCHAR(80),
	[NpmName]                  NVARCHAR(80),
	[RcCode]                   NVARCHAR(80),
	[RcName]                   NVARCHAR(80),
	[LowerName]                NVARCHAR(80),
	[Amount]                   DECIMAL(18, 0),
	[Budgeted]                 DECIMAL(18, 0),
	[Posted]                   DECIMAL(18, 0),
	[OpenCommitments]          DECIMAL(18, 0),
	[ULO]                      DECIMAL(18, 0),
	[Expenditures]             DECIMAL(18, 0),
	[Obligations]              DECIMAL(18, 0),
	[Used]                     DECIMAL(18, 0),
	[Available]                DECIMAL(18, 0),
	[Balance]                  DECIMAL(18, 0)
);

CREATE TABLE [StatusOfSupplementalFunding]
(
	[SupplementalAuthorityId] INT NOT NULL IDENTITY (15013,1),
	[StatusOfFundsId]         INT,
	[BudgetLevel]             NVARCHAR(80),
	[BFY]                     NVARCHAR(80),
	[EFY]                     NVARCHAR(80),
	[RpioCode]                NVARCHAR(80),
	[RpioName]                NVARCHAR(80),
	[AhCode]                  NVARCHAR(80),
	[AhName]                  NVARCHAR(80),
	[FundCode]                NVARCHAR(80),
	[FundName]                NVARCHAR(80),
	[OrgCode]                 NVARCHAR(80),
	[OrgName]                 NVARCHAR(80),
	[AccountCode]             NVARCHAR(80),
	[BocCode]                 NVARCHAR(80),
	[BocName]                 NVARCHAR(80),
	[ProgramProjectCode]      NVARCHAR(80),
	[ProgramProjectName]      NVARCHAR(80),
	[ProgramAreaCode]         NVARCHAR(80),
	[ProgramAreaName]         NVARCHAR(80),
	[RcCode]                  NVARCHAR(80),
	[RcName]                  NVARCHAR(80),
	[LowerName]               NVARCHAR(80),
	[Amount]                  DECIMAL(18, 0),
	[Budgeted]                DECIMAL(18, 0),
	[Posted]                  DECIMAL(18, 0),
	[OpenCommitments]         DECIMAL(18, 0),
	[ULO]                     DECIMAL(18, 0),
	[Expenditures]            DECIMAL(18, 0),
	[Obligations]             DECIMAL(18, 0),
	[Used]                    DECIMAL(18, 0),
	[Available]               DECIMAL(18, 0),
	[Balance]                 DECIMAL(18, 0),
	[NpmCode]                 NVARCHAR(80),
	[NpmName]                 NVARCHAR(80)
);

CREATE TABLE [SuperfundSites]
(
	[SuperfundSitesId] INT NOT NULL IDENTITY (13718,1),
	[RpioCode]         NVARCHAR(80),
	[RpioName]         NVARCHAR(80),
	[City]             NVARCHAR(80),
	[State]            NVARCHAR(80),
	[SSID]             NVARCHAR(80),
	[SiteProjectName]  NVARCHAR(80),
	[EpaSiteId]        NVARCHAR(80)
);

CREATE TABLE [SupplementalCarryoverEstimates]
(
	[SupplementalCarryoverEstimatesID] INT NOT NULL IDENTITY (765,1),
	[BFY]                              NVARCHAR(80),
	[EFY]                              NVARCHAR(80),
	[FundCode]                         NVARCHAR(80),
	[FundName]                         NVARCHAR(80),
	[TreasuryAccountCode]              NVARCHAR(80),
	[RpioCode]                         NVARCHAR(80),
	[RpioName]                         NVARCHAR(80),
	[Amount]                           DECIMAL(18, 0),
	[OpenCommitments]                  DECIMAL(18, 0),
	[Obligations]                      DECIMAL(18, 0),
	[Available]                        DECIMAL(18, 0),
	[Estimate]                         DECIMAL(18, 0)
);

CREATE TABLE [SupplementalReimburseableEstimates]
(
	[ReimbursableEstimatesId] INT NOT NULL IDENTITY (2,1),
	[BFY]                     NVARCHAR(80),
	[EFY]                     NVARCHAR(80),
	[FundCode]                NVARCHAR(80),
	[FundName]                NVARCHAR(80),
	[RpioCode]                NVARCHAR(80),
	[RpioName]                NVARCHAR(80),
	[Amount]                  DECIMAL(18, 0),
	[OpenCommitments]         DECIMAL(18, 0),
	[Obligations]             DECIMAL(18, 0),
	[Available]               DECIMAL(18, 0),
	[Estimate]                DECIMAL(18, 0)
);

CREATE TABLE [Transfers]
(
	[TransfersId]         INT NOT NULL IDENTITY (2,1),
	[BudgetLevel]         NVARCHAR(80),
	[DocPrefix]           NVARCHAR(80),
	[DocType]             NVARCHAR(80),
	[BFY]                 NVARCHAR(80),
	[RpioCode]            NVARCHAR(80),
	[RpioName]            NVARCHAR(80),
	[FundCode]            NVARCHAR(80),
	[FundName]            NVARCHAR(80),
	[ReprogrammingNumber] NVARCHAR(80),
	[ControlNumber]       NVARCHAR(80),
	[ProcessedDate]       DATETIME,
	[Quarter]             NVARCHAR(80),
	[Line]                NVARCHAR(80),
	[Subline]             NVARCHAR(80),
	[AhCode]              NVARCHAR(80),
	[AhName]              NVARCHAR(80),
	[OrgCode]             NVARCHAR(80),
	[OrgName]             NVARCHAR(80),
	[RcCode]              NVARCHAR(80),
	[RcName]              NVARCHAR(80),
	[AccountCode]         NVARCHAR(80),
	[ProgramAreaCode]     NVARCHAR(80),
	[ProgramAreaName]     NVARCHAR(80),
	[ProgramProjectName]  NVARCHAR(80),
	[ProgramProjectCode]  NVARCHAR(80),
	[FromTo]              NVARCHAR(80),
	[BocCode]             NVARCHAR(80),
	[BocName]             NVARCHAR(80),
	[NpmCode]             NVARCHAR(80),
	[Amount]              DECIMAL(18, 0),
	[Purpose]             NTEXT,
	[ExtendedPurpose]     NTEXT,
	[ResourceType]        NVARCHAR(80)
);

CREATE TABLE [TransTypes]
(
	[TransTypesId]          INT NOT NULL IDENTITY (97,1),
	[FundCode]              NVARCHAR(80),
	[Appropriation]         NVARCHAR(80),
	[BFY]                   NVARCHAR(80),
	[EFY]                   NVARCHAR(80),
	[TreasurySymbol]        NVARCHAR(80),
	[DocType]               NVARCHAR(80),
	[AppropriationBill]     NVARCHAR(80),
	[ContinuingResolution]  NVARCHAR(80),
	[RescissionCurrentYear] NVARCHAR(80),
	[RescissionPriorYear]   NVARCHAR(80),
	[SequesterReduction]    NVARCHAR(80),
	[SequesterReturn]       NVARCHAR(80)
);

CREATE TABLE [TravelActivity]
(
	[TravelActivityId]      INT NOT NULL IDENTITY (2,1),
	[RpioCode]              NVARCHAR(80),
	[RpioName]              NVARCHAR(80),
	[BFY]                   NVARCHAR(80),
	[AhCode]                NVARCHAR(80),
	[AhName]                NVARCHAR(80),
	[FundCode]              NVARCHAR(80),
	[FundName]              NVARCHAR(80),
	[AccountCode]           NVARCHAR(80),
	[ProgramProjectCode]    NVARCHAR(80),
	[ProgramProjectName]    NVARCHAR(80),
	[OrgCode]               NVARCHAR(80),
	[OrgName]               NVARCHAR(80),
	[BocCode]               NVARCHAR(80),
	[BocName]               NVARCHAR(80),
	[RcCode]                NVARCHAR(80),
	[RcName]                NVARCHAR(80),
	[FocCode]               NVARCHAR(80),
	[FocName]               NVARCHAR(80),
	[FirstName]             NVARCHAR(80),
	[LastName]              NVARCHAR(80),
	[StartDate]             DATETIME,
	[EndDate]               DATETIME,
	[Duration]              FLOAT,
	[DocumentControlNumber] NVARCHAR(80),
	[Obligations]           DECIMAL(18, 0),
	[ULO]                   DECIMAL(18, 0),
	[Expenditures]          DECIMAL(18, 0)
);

CREATE TABLE [UnliquidatedObligations]
(
	[UnliquidatedObligationsId] INT NOT NULL IDENTITY (82357,1),
	[ObligationsId]             INT,
	[BFY]                       NVARCHAR(80),
	[EFY]                       NVARCHAR(80),
	[RpioCode]                  NVARCHAR(80),
	[RpioName]                  NVARCHAR(80),
	[AhCode]                    NVARCHAR(80),
	[AhName]                    NVARCHAR(80),
	[FundCode]                  NVARCHAR(80),
	[FundName]                  NVARCHAR(80),
	[OrgCode]                   NVARCHAR(80),
	[OrgName]                   NVARCHAR(80),
	[AccountCode]               NVARCHAR(80),
	[ProgramProjectCode]        NVARCHAR(80),
	[ProgramProjectName]        NVARCHAR(80),
	[RcCode]                    NVARCHAR(80),
	[RcName]                    NVARCHAR(80),
	[DocumentType]              NVARCHAR(80),
	[DocumentNumber]            NVARCHAR(80),
	[DocumentControlNumber]     NVARCHAR(80),
	[TreasurySymbol]            NVARCHAR(80),
	[OmbAccountCode]            NVARCHAR(80),
	[OmbAccountName]            NVARCHAR(80),
	[ProcessedDate]             DATETIME,
	[LastActivityDate]          DATETIME,
	[Age]                       FLOAT,
	[BocCode]                   NVARCHAR(80),
	[BocName]                   NVARCHAR(80),
	[FocCode]                   NVARCHAR(80),
	[FocName]                   NVARCHAR(80),
	[NpmCode]                   NVARCHAR(80),
	[NpmName]                   NVARCHAR(80),
	[VendorCode]                NVARCHAR(80),
	[VendorName]                NVARCHAR(80),
	[Amount]                    DECIMAL(18, 0)
);

CREATE TABLE [UnobligatedAuthority]
(
	[UnobligatedAuthorityId] INT NOT NULL IDENTITY (49,1),
	[ReportYear]             NVARCHAR(80),
	[AgencyCode]             NVARCHAR(80),
	[BureauCode]             NVARCHAR(80),
	[AccountCode]            NVARCHAR(80),
	[OmbAccount]             NVARCHAR(80),
	[OmbAccountName]         NVARCHAR(80),
	[LineName]               NVARCHAR(80),
	[LineNumber]             NVARCHAR(80),
	[BudgetYear]             DECIMAL(18, 0),
	[PriorYear]              DECIMAL(18, 0),
	[CurrentYear]            DECIMAL(18, 0),
	[AgencyName]             NVARCHAR(80),
	[BureauName]             NVARCHAR(80)
);

CREATE TABLE [UnobligatedBalances]
(
	[UnobligatedBalancesId] INT NOT NULL IDENTITY (35334,1),
	[BudgetYear]            NVARCHAR(80),
	[BFY]                   NVARCHAR(80),
	[EFY]                   NVARCHAR(80),
	[TreasurySymbol]        NVARCHAR(80),
	[FundCode]              NVARCHAR(80),
	[FundName]              NVARCHAR(80),
	[OmbAccountCode]        NVARCHAR(80),
	[AccountNumber]         NVARCHAR(80),
	[AccountName]           NVARCHAR(80),
	[Amount]                DECIMAL(18, 0)
);

CREATE TABLE [URL]
(
	[UrlsId]   INT NOT NULL IDENTITY (35,1),
	[Name]     NVARCHAR(80),
	[Location] NVARCHAR(80),
	[Address]  NTEXT
);
