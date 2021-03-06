﻿/* Copyright 2010-2013 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Driver
{
    /// <summary>
    /// Represents the results of a Aggregate command.
    /// </summary>
    [Serializable]
    [BsonSerializer(typeof(CommandResultSerializer))]
    public class AggregateResult : CommandResult
    {
        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateResult"/> class.
        /// </summary>
        /// <param name="response">The response.</param>
        public AggregateResult(BsonDocument response)
            : base(response)
        {
        }

        // public properties
        /// <summary>
        /// Gets the results of the aggregation.
        /// </summary>
        public IEnumerable<BsonDocument> ResultDocuments
        {
            get { return Response["result"].AsBsonArray.Select(v => v.AsBsonDocument); }
        }
    }
}
