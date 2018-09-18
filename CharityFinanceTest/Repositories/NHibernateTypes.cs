using System;
using FinanceDomain;
using NHibernate.Type;

namespace Repositories
{
    [Serializable]
    public class PaymentGiftAidStatusType : EnumStringType<GiftAidStatus>
    {
    }
}