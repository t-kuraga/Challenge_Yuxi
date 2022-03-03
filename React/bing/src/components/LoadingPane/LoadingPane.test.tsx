import { render, screen } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import LoadingPane from './LoadingPane';

describe('<LoadingPane />', () => {
  test('it should mount', () => {
    // Act
    render(<LoadingPane />);
    // Assert
    expect(screen.getByTestId('LoadingPane')).toBeInTheDocument();
  });

  test('it should mount with custom message', () => {
    // Arrange
    const expectedMessage = "Fake Loading";

    // Act
    render(<LoadingPane message={expectedMessage}/>);

    // Assert
    expect(screen.getByTestId('LoadingPane')).toBeInTheDocument();
    expect(screen.getByText(expectedMessage)).toBeInTheDocument();
  });

  test('it should mount with full overlay', () => {
    // Act
    render(<LoadingPane fullOverlay={true}/>);

    //Assert
    expect(screen.getByTestId('LoadingPane').classList).toContain('fullOverlay');
  });

});