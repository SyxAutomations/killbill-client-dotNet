/*
 * Copyright 2010-2014 Ning, Inc.
 *
 * Ning licenses this file to you under the Apache License, version 2.0
 * (the "License"); you may not use this file except in compliance with the
 * License.  You may obtain a copy of the License at:
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Killbill_Client;
using Killbill_Client.model;

namespace Killbill_Client.model {
    
public abstract class KillBillObjects<T> : List<T> where T : KillBillObject {

    
    private KillBillHttpClient killBillHttpClient;

    
    private int paginationCurrentOffset;

    
    private int paginationNextOffset;

    
    private int paginationTotalNbRecords;

    
    private int paginationMaxNbRecords;

    
    private string paginationNextPageUri;

    
    public T getNext<T>(Type clazz) {
        if (killBillHttpClient == null || paginationNextPageUri == null) {
            return null;
        }
        return killBillHttpClient.doGet(paginationNextPageUri, KillBillHttpClient.DEFAULT_EMPTY_QUERY, clazz);
    }


    }
   
}
