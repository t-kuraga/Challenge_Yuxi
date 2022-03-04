import React, { lazy, Suspense } from 'react';
import LayoutProps from './LayoutProps';

const LazyLayout = lazy(() => import('./Layout'));

const Layout = (props: LayoutProps) => (
  <Suspense fallback={null}>
    <LazyLayout {...props} />
  </Suspense>
);

export default Layout;
