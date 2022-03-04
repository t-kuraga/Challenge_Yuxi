import React, { lazy, Suspense } from 'react';

const LazySearchForm = lazy(() => import('./SearchForm'));

const SearchForm = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode; }) => (
  <Suspense fallback={null}>
    <LazySearchForm {...props} />
  </Suspense>
);

export default SearchForm;
