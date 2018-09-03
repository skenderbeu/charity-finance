using System;
using FinanceEntities;
using NHibernate.Type;

namespace Repositories
{
    [Serializable]
    public class PaymentGiftAidStatusType : EnumStringType<GiftAidStatus>
    {
    }
}