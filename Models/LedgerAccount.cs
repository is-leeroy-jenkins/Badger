namespace Badger
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc />
    /// <summary>
    /// </summary>
    /// <seealso cref="T:Badger.DataUnit" />
    [ SuppressMessage( "ReSharper", "RedundantBaseConstructorCall" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public abstract class LedgerAccount : DataUnit
    {
        /// <summary>
        /// The bfy
        /// </summary>
        private protected string _bfy;

        /// <summary>
        /// The account classification
        /// </summary>
        private protected string _accountClassification;

        /// <summary>
        /// The short name
        /// </summary>
        private protected string _shortName;

        /// <summary>
        /// The number
        /// </summary>
        private protected string _number;

        /// <summary>
        /// The normal balance
        /// </summary>
        private protected string _normalBalance;

        /// <summary>
        /// The real or closing account
        /// </summary>
        private protected string _realOrClosingAccount;

        /// <summary>
        /// The summary account
        /// </summary>
        private protected string _summaryAccount;

        /// <summary>
        /// The cash account
        /// </summary>
        private protected string _cashAccount;

        /// <summary>
        /// The reportable account
        /// </summary>
        private protected string _reportableAccount;

        /// <summary>
        /// The cost allocation indicator
        /// </summary>
        private protected string _costAllocationIndicator;

        /// <summary>
        /// The federal non federal
        /// </summary>
        private protected string _federalNonFederal;

        /// <summary>
        /// The attribute value
        /// </summary>
        private protected string _attributeValue;

        /// <summary>
        /// The usage
        /// </summary>
        private protected string _usage;

        /// <summary>
        /// The deposit
        /// </summary>
        private protected string _deposit;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.LedgerAccount" /> class.
        /// </summary>
        protected LedgerAccount( ) 
            : base( )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.LedgerAccount" /> class.
        /// </summary>
        /// <param name="query">The query.</param>
        protected LedgerAccount( IQuery query ) 
            : base( query )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.LedgerAccount" /> class.
        /// </summary>
        /// <param name="builder"></param>
        protected LedgerAccount( IDataModel builder ) 
            : base( builder )
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.LedgerAccount" /> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        protected LedgerAccount( DataRow dataRow ) 
            : base( dataRow )
        {
        }
    }
}
