using System;
namespace Enoca.Entity.Concrete
{
	public class BaseEntity<TKey>
	{
        public TKey Id { get; set; }
    }
}

