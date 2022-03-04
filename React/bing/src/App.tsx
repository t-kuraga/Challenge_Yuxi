import './App.css';
import './i18n.js';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Container } from 'react-bootstrap';
import SpinnerProvider from './contexts/SpinnerContext/SpinnerContext';
import SearchProvider from './contexts/SearchContext/SearchContext';
import Layout from './components/Layout/Layout.lazy';
import SearchForm from './components/SearchForm/SearchForm.lazy';
import SearchResultsList from './components/SearchResultsList/SearchResultsList.lazy';

function App() {

  return (
    <Container className="App">
      <SpinnerProvider>
        <SearchProvider>
          <Layout>
              <SearchForm />
              <SearchResultsList />
          </Layout>
        </SearchProvider>
      </SpinnerProvider>
    </Container>
  );
}

export default App;
