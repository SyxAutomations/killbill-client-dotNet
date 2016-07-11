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

namespace Killbill_Client.model {









Properties(ignoreUnknown = true)
public abstract class KillBillObjects<T : KillBillObject> : ArrayList<T> {

    
    private KillBillHttpClient killBillHttpClient;

    
    private int paginationCurrentOffset;

    
    private int paginationNextOffset;

    
    private int paginationTotalNbRecords;

    
    private int paginationMaxNbRecords;

    
    private string paginationNextPageUri;

    
    public <U : KillBillObjects<T>> U getNext(Class<U> clazz) throws KillBillClientException {
        if (killBillHttpClient == null || paginationNextPageUri == null) {
            return null;
        }
        return killBillHttpClient.doGet(paginationNextPageUri, KillBillHttpClient.DEFAULT_EMPTY_QUERY, clazz);
    }

    
    public KillBillHttpClient getKillBillHttpClient() {
        return killBillHttpClient;
    }

    
    public void setKillBillHttpClient(KillBillHttpClient killBillHttpClient) {
        this.killBillHttpClient = killBillHttpClient;
    }

    
    public int getPaginationCurrentOffset() {
        return paginationCurrentOffset;
    }

    
    public void setPaginationCurrentOffset(int paginationCurrentOffset) {
        this.paginationCurrentOffset = paginationCurrentOffset;
    }

    
    public int getPaginationNextOffset() {
        return paginationNextOffset;
    }

    
    public void setPaginationNextOffset(int paginationNextOffset) {
        this.paginationNextOffset = paginationNextOffset;
    }

    
    public int getPaginationTotalNbRecords() {
        return paginationTotalNbRecords;
    }

    
    public void setPaginationTotalNbRecords(int paginationTotalNbRecords) {
        this.paginationTotalNbRecords = paginationTotalNbRecords;
    }

    
    public int getPaginationMaxNbRecords() {
        return paginationMaxNbRecords;
    }

    
    public void setPaginationMaxNbRecords(int paginationMaxNbRecords) {
        this.paginationMaxNbRecords = paginationMaxNbRecords;
    }

    
    public string getPaginationNextPageUri() {
        return paginationNextPageUri;
    }

    
    public void setPaginationNextPageUri(string paginationNextPageUri) {
        this.paginationNextPageUri = paginationNextPageUri;
    }
}
