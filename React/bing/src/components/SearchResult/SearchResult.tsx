import { FC } from 'react';
import { Card } from 'react-bootstrap';
import styles from './SearchResult.module.css';
import SearchResultProps from './SearchResultProps';

const SearchResult: FC<SearchResultProps> = ({ result }) => (
  <Card className={styles.SearchResult} data-testid="SearchResult">
    <Card.Body>
      <Card.Title><Card.Link href={result.displayUrl}>{result.name}</Card.Link></Card.Title>
      <Card.Text>
        {result.snippet}
      </Card.Text>
    </Card.Body>
  </Card>
);

export default SearchResult;
