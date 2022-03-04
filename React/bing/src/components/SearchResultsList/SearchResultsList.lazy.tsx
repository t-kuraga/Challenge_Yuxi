import React, { lazy, Suspense } from 'react';

const LazySearchResultsList = lazy(() => import('./SearchResultsList'));

const SearchResultsList = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode; }) => (
  <Suspense fallback={null}>
    <LazySearchResultsList {...props} />
  </Suspense>
);

export default SearchResultsList;
