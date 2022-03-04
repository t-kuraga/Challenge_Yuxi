import { FC } from 'react';
import { useSearch } from '../../contexts/SearchContext/SearchContext';
import SearchResult from '../SearchResult/SearchResult.lazy';
import styles from './SearchResultsList.module.css';

interface SearchResultsListProps { }

const SearchResultsList: FC<SearchResultsListProps> = () => {
  var search = useSearch();

  return (
    !!search?.results ?
      <div className={styles.SearchResultsList} data-testid="SearchResultsList">
        {search.results.map(result => <SearchResult {...{result}} />)}
      </div> : null
  )
};

export default SearchResultsList;
