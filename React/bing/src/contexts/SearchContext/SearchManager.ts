import { SearchResponse, Value } from "./SearchResponse";

/**
 * Search manager
 */
export default interface SearchManager{
    /**
     * Results observer
     */
    results:Value[],
    /**
     * Searches for a query string
     * @param {string} query Target query string
     * @returns {Promise<SearchResponse>} Search response
     */
    searchFor: (query:string) => Promise<Value[]>
}