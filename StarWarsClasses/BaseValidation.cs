using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsClasses
{
    /// <summary>
    /// 
    /// </summary>
    public abstract  class BaseValidation
    {

        /// <summary>
        /// The ComboBoxData Dictionary
        /// </summary>
        protected Dictionary<int, string> _objComboBoxData;
        /// <summary>
        /// The _validated
        /// </summary>
        protected bool _validated = false;
        /// <summary>
        /// The _validation message
        /// </summary>
        protected StringBuilder _validationMessage;
        /// <summary>
        /// The _delete ok
        /// </summary>
        protected bool _deleteOK = true;
        /// <summary>
        /// The _deletion message
        /// </summary>
        protected StringBuilder _deletionMessage;

        /// <summary>
        /// The _insert update ok
        /// </summary>
        protected bool _insertUpdateOK = true;

        /// <summary>
        /// The _insert update message
        /// </summary>
        protected StringBuilder _insertUpdateMessage;

        #region Properties
        /// <summary>
        /// Gets a value indicating whether this <see cref="BaseValidation"/> is validated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if validated; otherwise, <c>false</c>.
        /// </value>
        public bool Validated
        {
            get { return _validated; }
        }

        /// <summary>
        /// Gets the validation message.
        /// </summary>
        /// <value>
        /// The validation message.
        /// </value>
        public string ValidationMessage
        {
            get { return _validationMessage.ToString(); }
        }

        public Dictionary<int, string> objComboBoxData
        {
            get { return _objComboBoxData; }
        }

        /// <summary>
        /// Gets a value indicating whether [delete ok].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [delete ok]; otherwise, <c>false</c>.
        /// </value>
        public bool DeleteOK
        {
            get { return _deleteOK; }
        }

        /// <summary>
        /// Gets the deletion message.
        /// </summary>
        /// <value>
        /// The deletion message.
        /// </value>
        public string DeletionMessage
        {
            get { return _deletionMessage.ToString(); }
        }
        
        /// <summary>
        /// Gets a value indicating whether [insert update ok].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [insert update ok]; otherwise, <c>false</c>.
        /// </value>
        public bool InsertUpdateOK
        {
            get { return _insertUpdateOK; }
        }

        /// <summary>
        /// Gets the insert update message.
        /// </summary>
        /// <value>
        /// The insert update message.
        /// </value>
        public string InsertUpdateMessage
        {
            get { return _insertUpdateMessage.ToString(); }
        }
        #endregion

        #region Abstract Methods
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        abstract public bool Validate();

        protected void SetBaseConstructorOptions()
        {
            _validationMessage = new StringBuilder();
            _deletionMessage = new StringBuilder();
            _insertUpdateMessage = new StringBuilder();
            _objComboBoxData = new Dictionary<int, string>();

        }
        #endregion
    }
}
