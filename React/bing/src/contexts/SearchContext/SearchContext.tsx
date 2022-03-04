import React, { useContext, useState } from 'react';
import SearchManager from './SearchManager';
import { SearchResponse, Value } from './SearchResponse';

/**
 * End-Point configuration
 */
const bingConfig = {
  apiKey: process.env.REACT_APP_BING_API_KEY,
  endPoint: process.env.REACT_APP_BING_END_POINT
};

/**
 * Search provider properties
 */
interface SearchProviderProps {
  children?: JSX.Element | JSX.Element[] | string
}

/**
 * Search context
 */
const SearchContext = React.createContext<SearchManager | null>(null);


/**
* Search hook
* @Search Search context
*/
export function useSearch(): SearchManager | null {
  return useContext(SearchContext)
}

/**
 * Search provider
 * @returns Component
 */
export default function SearchProvider({ children }: SearchProviderProps) {

  const [results, setResults] = useState<Value[]>(undefined!);

  // Context value
  const value: SearchManager = {
    results,
    searchFor: async q => {
      // Build a url with the query
      var url = `${bingConfig.endPoint}/v7.0/search?q=${q}&mkt=en-US&count=10&responseFilter=webPages&freshness=day`;

      try {
        // Set the request headers
        const headers = new Headers({
          'content-type': 'application/json'
        });
        headers.set("Ocp-Apim-Subscription-Key", bingConfig.apiKey ?? "");
        const opts: RequestInit = {
          method: 'GET',
          headers,
        };

        // Call the api
        let response = await fetch(url, opts);
        let searthResponse:SearchResponse = await response.json();
        
        // update results
        setResults(searthResponse.webPages.value);

        return results;
      } catch (error) {
        throw error;
      }
    }
  };

  return (
    <SearchContext.Provider value={value}>
      {children}
    </SearchContext.Provider>
  )
}
