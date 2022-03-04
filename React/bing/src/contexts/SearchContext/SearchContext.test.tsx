import React from 'react';
import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import SearchContext from './SearchContext';

describe('<SearchContext />', () => {
  test('it should mount', () => {
    render(<SearchContext>Fake Content</SearchContext>);
    
    const content = screen.getByText('Fake Content');

    expect(content).toBeInTheDocument();
  });
});