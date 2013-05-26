using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquarePeg.Common.DependencyInjection
{
    using Funq;

    public class SharedContainer
    {
        /// <summary>
        /// The container
        /// </summary>
        private static Funq.Container container = null;

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static Funq.Container Container
        {
            get
            {
                if (container == null)
                {
                    container = new Container();
                }

                return container;
            }

            set
            {
                container = value;
            }
        }
    }
}
