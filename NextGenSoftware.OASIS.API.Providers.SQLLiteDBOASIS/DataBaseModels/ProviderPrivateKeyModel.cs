using System;
using System.ComponentModel.DataAnnotations.Schema;
using NextGenSoftware.OASIS.API.Core.Enums;

namespace NextGenSoftware.OASIS.API.Providers.SQLLiteDBOASIS.DataBaseModels{

    [Table("ProviderPrivateKey")]
    public class ProviderPrivateKeyModel : ProviderKeyAbstract
    {
        public ProviderPrivateKeyModel():base(){}
        public ProviderPrivateKeyModel(ProviderType Id, String value) : base(Id,value){}

        public override ProviderKeyAbstract GetProviderKey()
        {
            ProviderKeyAbstract item=new ProviderPrivateKeyModel();

            item.KeyId=this.KeyId;
            item.Value=this.Value;

            return(item);
        }
    }

}