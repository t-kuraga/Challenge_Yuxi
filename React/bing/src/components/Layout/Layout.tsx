import { FC } from 'react';
import { Container } from 'react-bootstrap';
import styles from './Layout.module.css';
import LayoutProps from './LayoutProps';


const Layout: FC<LayoutProps> = ({ children }: LayoutProps) => (
  <div className={styles.Layout} data-testid="Layout">
    <Container className={styles.Content} data-testid="Content">
      {children}
    </Container>
  </div>
);

export default Layout;
