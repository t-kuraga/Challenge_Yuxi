import { FC, useRef, useState } from 'react';
import { Alert, Button } from 'react-bootstrap';
import Card from 'react-bootstrap/esm/Card';
import Form from 'react-bootstrap/esm/Form';
import { useTranslation } from 'react-i18next';
import { useSearch } from '../../contexts/SearchContext/SearchContext';
import { useSpinner } from '../../contexts/SpinnerContext/SpinnerContext';
import styles from './SearchForm.module.css';

interface SearchFormProps { }

const SearchForm: FC<SearchFormProps> = () => {
  const [errorMessage, setErrorMessage] = useState<string>();
  const searchRef = useRef<HTMLInputElement>(undefined!);
  const { t } = useTranslation();
  const spinner = useSpinner();
  const search = useSearch();

  const handleSubmit = async (ev:any) => {
    ev.preventDefault();

    try {
      setErrorMessage(""); // Reset error message
      spinner.show();
      await search?.searchFor(searchRef.current.value);
      debugger;
    } catch (error) {
      setErrorMessage(`${t("Search Failed")}: ${t(`${error}`)}`);
    } finally {
      spinner.hide();
    }
  }
  return (
    <Card className={styles.SearchForm} data-testid="SearchForm">
      <Card.Body>
        {errorMessage && <Alert variant="danger" data-testid="errorMessage">{errorMessage}</Alert>}
        <Form onSubmit={handleSubmit}>
          <Form.Group id="search">
            <Form.Control type="text" placeholder={t("Search")} ref={searchRef} required data-testid="SearchField" />
          </Form.Group>
          <Button type="submit" className="w-100" data-testid="searchButton">{t("Search")}</Button>
        </Form>
      </Card.Body>
    </Card >
  );
}
export default SearchForm;
