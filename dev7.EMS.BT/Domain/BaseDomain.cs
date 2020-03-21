using dev7.EMS.BT.Utilities;
using dev7.EMS.Domain.ResultMessages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dev7.EMS.BT.Domain
{
    public interface IBase // Marker interface
    {

    }
    //Base Entity Class for shared fields and functionalities.
    public abstract partial class BaseDomain // : IBase
    {
        public BaseDomain()
        {
            CreatedById = 0;
            CreatedDate = DateTime.Now;
            IsActive = true;
            ResultMessages = new List<ResultMessage>();
        }
        public  long CreatedById { get; set; }
        public  DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        [NotMapped]
        public string Msg { get; set; }

        [NotMapped]
        public bool HasError { get; set; }
        [NotMapped]
        public virtual bool IsValid { get; set; }
        [NotMapped]
        public IList<ResultMessage> ResultMessages { get; set; }

        /// <summary>
        /// It would Encode Domain Object to Key:Value pair Form
        /// e.g. Id:100|Name:Ali|Gender:M|Cell:03233483484 ...
        /// </summary>
        /// <returns></returns>
        public virtual string Encode() { return null; }
        public virtual string Encode(BaseDomain obj) { return null; }

        /// <summary>
        /// It is reverse of Encode ... It would translate back the Encoded string longo Object Form 
        /// </summary>
        /// <returns></returns>
        protected virtual IBase Decode() { return null; }

        #region methods

        public void AddSuccessMessage(string message)
        {
            AddResultMessage(message, false, ResultCode.Success);
        }

        public T AddSuccessMessage<T>(T model, string message) where T : BaseDomain
        {
            return AddResultMessage(model, message, false, ResultCode.Success);
        }

        public void AddWarningMessage(string message)
        {
            AddResultMessage(message, true, ResultCode.Warning);
        }

        public T AddWarningMessage<T>(T model, string message) where T : BaseDomain
        {
            return AddResultMessage(model, message, true, ResultCode.Warning);
        }

        public T ClearAllUserMessages<T>(T model) where T : BaseDomain
        {
            model.HasError = false;
            model.ResultMessages.Clear();
            return model;
        }

        public void AddErrorMessage(string message)
        {
            AddResultMessage(message, true, ResultCode.Danger);
        }

        public T AddErrorMessage<T>(T model, string message) where T : BaseDomain
        {
            return AddResultMessage(model, message, true, ResultCode.Danger);
        }

        public void AddUserMessage(string message, bool hasErrors, ResultCode resultCode)
        {
            AddResultMessage(message, hasErrors, resultCode);
        }

        public T AddUserMessage<T>(T model, string message, bool hasErrors, ResultCode resultCode) where T : BaseDomain
        {
            return AddResultMessage(model, message, hasErrors, resultCode);
        }

        private static T AddResultMessage<T>(T model, string message, bool hasErrors, ResultCode resultCode) where T : BaseDomain
        {
            model.HasError = hasErrors;
            model.ResultMessages.Add(new ResultMessage { Message = message, MessageType = resultCode.ToString().ToLowerInvariant() });
            return model;
        }

        private void AddResultMessage(string message, bool hasErrors, ResultCode resultCode)
        {
            HasError = hasErrors;
            ResultMessages.Add(new ResultMessage { Message = message, MessageType = resultCode.ToString().ToLowerInvariant() });
        }

        #endregion methods
    }
}
