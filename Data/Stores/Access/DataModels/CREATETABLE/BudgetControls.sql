CREATE TABLE BudgetControls
(
	BudgetControlsId                      AUTOINCREMENT NOT NULL UNIQUE,
	Code                                  TEXT( 150 )   NULL DEFAULT NS,
	Name                                  TEXT( 150 )   NULL DEFAULT NS,
	BudgetedTransType                     TEXT( 150 )   NULL DEFAULT NS,
	PostedTransType                       TEXT( 150 )   NULL DEFAULT NS,
	EstimatedReimbursementsTransType      TEXT( 150 )   NULL DEFAULT NS,
	SpendingAdjustmentTransType           TEXT( 150 )   NULL DEFAULT NS,
	EstimatedRecoveriesTransType          TEXT( 150 )   NULL DEFAULT NS,
	ActualRecoveriesTransType             TEXT( 150 )   NULL DEFAULT NS,
	StatusReserveTransType                TEXT( 150 )   NULL DEFAULT NS,
	ProfitLossTransType                   TEXT( 150 )   NULL DEFAULT NS,
	EstimatedReimbursementsSpendingOption TEXT( 150 )   NULL DEFAULT NS,
	EstimatedReimursementsBudgetingOption TEXT( 150 )   NULL DEFAULT NS,
	TrackAgreementLowerLevel              TEXT( 150 )   NULL DEFAULT NS,
	BudgetEstimatedLowerLevel             TEXT( 150 )   NULL DEFAULT NS,
	EstimatedRecoveriesSpendingOption     TEXT( 150 )   NULL DEFAULT NS,
	EstimatedRecoveriesBudgetingOption    TEXT( 150 )   NULL DEFAULT NS,
	RecoveryNextLevel                     TEXT( 150 )   NULL DEFAULT NS,
	RecoveryBudgetMismatch                TEXT( 150 )   NULL DEFAULT NS,
	ProfitLossSpendingOption              TEXT( 150 )   NULL DEFAULT NS,
	ProfitLossBudgetOption                TEXT( 150 )   NULL DEFAULT NS,
	RecoveriesCarryInLowerLevel           TEXT( 150 )   NULL DEFAULT NS,
	RecoveriesCarryInLowerLevelControl    TEXT( 150 )   NULL DEFAULT NS,
	RecoveriesCarryInAmountControl        TEXT( 150 )   NULL DEFAULT NS,
	BudgetedControl                       TEXT( 150 )   NULL DEFAULT NS,
	PostedControl                         TEXT( 150 )   NULL DEFAULT NS,
	PreCommitmentSpendingControl          TEXT( 150 )   NULL DEFAULT NS,
	CommitmentSpendingControl             TEXT( 150 )   NULL DEFAULT NS,
	ObligationSpendingControl             TEXT( 150 )   NULL DEFAULT NS,
	AccrualSpendingControl                TEXT( 150 )   NULL DEFAULT NS,
	ExpenditureSpendingControl            TEXT( 150 )   NULL DEFAULT NS,
	ExpenseSpendingControl                TEXT( 150 )   NULL DEFAULT NS,
	ReimbursableSpendingControl           TEXT( 150 )   NULL DEFAULT NS,
	ReimbursableAgreementSpendingControl  TEXT( 150 )   NULL DEFAULT NS,
	FteBudgetingControl                   TEXT( 150 )   NULL DEFAULT NS,
	FteSpendingControl                    TEXT( 150 )   NULL DEFAULT NS,
	TransactionTypeControl                TEXT( 150 )   NULL DEFAULT NS,
	AuthorityDistributionControl          TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	BudgetControlsPrimaryKey
)
	PRIMARY KEY
(
	BudgetControlsId
)
	);
