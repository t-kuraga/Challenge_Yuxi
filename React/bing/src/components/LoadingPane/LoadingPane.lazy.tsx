import React, { FC, lazy, Suspense } from 'react';
import LoadingPaneProps from "./LoadingPaneProps";

const LazyLoadingPane = lazy(() => import('./LoadingPane'));

const LoadingPane: FC<LoadingPaneProps> = (props: LoadingPaneProps) => (
  <Suspense fallback={null}>
    <LazyLoadingPane {...props} />
  </Suspense>
);

export default LoadingPane;
