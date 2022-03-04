import React, { lazy, Suspense } from 'react';
import SearchResultProps from './SearchResultProps';

const LazySearchResult = lazy(() => import('./SearchResult'));

const SearchResult = (props: SearchResultProps) => (
  <Suspense fallback={null}>
    <LazySearchResult {...props} />
  </Suspense>
);

export default SearchResult;
