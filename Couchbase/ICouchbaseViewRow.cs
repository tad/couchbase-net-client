﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Couchbase
{
	public interface IViewRow
	{
		/// <summary>
		/// Returns the row key of this instance. (It is usually generated by the mapper.)
		/// </summary>
		object[] ViewKey { get; }
		/// <summary>
		/// Returns the id of the item referenced by this row. This id can be used to 
		/// perform the standard (Set/Get/Remove/etc.) operations on the item.
		/// </summary>
		string ItemId { get; }
		/// <summary>
		/// Returns all data from the row. These are usually parts of the original document emitted by the mapper (or the reducer).
		/// </summary>
		IDictionary<string, object> Info { get; }

		/// <summary>
		/// Returns the original item.
		/// </summary>
		/// <returns></returns>
		object GetItem();
	}
}

#region [ License information          ]
/* ************************************************************
 *
 *    @author Couchbase <info@couchbase.com>
 *    @copyright 2011 Couchbase, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * ************************************************************/
#endregion
