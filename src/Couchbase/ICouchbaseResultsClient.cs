﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enyim.Caching.Memcached.Results;
using Enyim.Caching.Memcached;
using Couchbase.Operations;

namespace Couchbase
{
	interface ICouchbaseResultsClient
	{
		IGetOperationResult ExecuteGet(string key, DateTime newExpiration);
		IGetOperationResult<T> ExecuteGet<T>(string key, DateTime newExpiration);
		IGetOperationResult ExecuteTryGet(string key, DateTime newExpiration, out object value);

		IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, PersistTo persistTo, ReplicateTo replicateTo);
		IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, ReplicateTo replicateTo);
		IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, PersistTo persistTo);

		IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, DateTime expiresAt, PersistTo persistTo, ReplicateTo replicateTo);
		IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, DateTime expiresAt, PersistTo persistTo);
		IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, DateTime expiresAt, ReplicateTo replicateTo);

		IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, TimeSpan validFor, PersistTo persistTo, ReplicateTo replicateTo);
		IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, TimeSpan validFor, PersistTo persistTo);
		IStoreOperationResult ExecuteStore(StoreMode mode, string key, object value, TimeSpan validFor, ReplicateTo replicateTo);

	}
}

#region [ License information          ]
/* ************************************************************
 * 
 *    @author Couchbase <info@couchbase.com>
 *    @copyright 2012 Couchbase, Inc. 
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