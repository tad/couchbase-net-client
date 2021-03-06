﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using Enyim.Caching.Memcached;
using System.Net;
using Newtonsoft.Json;

namespace Couchbase.Tests
{

	[TestFixture]
	public class CouchbaseClientGenericViewTests : CouchbaseClientViewTestsBase
	{
		[Test]
		public void When_Should_Lookup_By_Id_Is_True_Document_Is_Retrieved_By_Id()
		{
			var view = _Client.GetView<City>("cities", "by_name", true).Stale(StaleMode.False);
			foreach (var item in view)
			{
				Assert.That(item.Id, Is.Not.Null, "Item Id was null");
				Assert.That(item.Name, Is.Not.Null, "Item Name was null");
				Assert.That(item.State, Is.Not.Null, "Item State was null");
				Assert.That(item.Type, Is.EqualTo("city"), "Type was not city");
				Assert.That(item, Is.InstanceOf<City>(), "Item was not a City instance");
			}

			Assert.That(view.Count(), Is.GreaterThan(0), "View count was 0");
		}

		[Test]
		public void When_Should_Lookup_By_Id_Is_False_Document_Is_Deserialized_By_Property_Mapping()
		{
			var view = _Client.GetView<CityProjection>("cities", "by_city_and_state", false).Stale(StaleMode.False);
			foreach (var item in view)
			{
				Assert.That(item.CityState, Is.Not.Null, "CityState was null");
			}

			Assert.That(view.Count(), Is.GreaterThan(0), "View count was 0");
		}

		private class City
		{
			[JsonProperty("_id")]
			public string Id { get; set; }

			[JsonProperty("name")]
			public string Name { get; set; }

			[JsonProperty("state")]
			public string State { get; set; }

			[JsonProperty("type")]
			public string Type { get; set; }
		}

		private class CityProjection
		{
			[JsonProperty("cityState")]
			public string CityState { get; set; }
		}
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
