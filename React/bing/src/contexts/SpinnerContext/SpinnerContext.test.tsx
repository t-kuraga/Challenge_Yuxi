import React, { useEffect } from 'react';
import { render, screen, waitFor } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import SpinnerProvider, { useSpinner } from './SpinnerContext';
import { act } from 'react-dom/test-utils';
import SpinnerManager from './SpinnerManager';
import LoadingPaneProps from '../../components/LoadingPane/LoadingPaneProps';

jest.mock('react-i18next', () => ({
    useTranslation: () => ({ t: (str: string) => str })
}));


jest.mock('../../components/LoadingPane/LoadingPane.lazy',
    () => (p:LoadingPaneProps) => {
        return (<div data-testid="fakeLoadingPane">Fake Loading Pane: <span>{p.message}</span></div>);
    });


describe('<SpinnerContext />', () => {
    test('it should mount', () => {
        render(<SpinnerProvider>Fake Content</SpinnerProvider>);
        const contentContainer = screen.getByTestId('ContentContainer');
        expect(contentContainer).toHaveStyle({ display: 'block' });
    });

    test('it should hide spinner', async () => {
        const FakeComponent = () => {
            var spinner = useSpinner();

            useEffect(() => {
                spinner?.hide();
            }, []);

            return (<div data-testid="fakeContent">Fake Content</div>);
        }

        render(<SpinnerProvider><FakeComponent /></SpinnerProvider>);
        await waitFor(async () => expect(await screen.findByTestId('ContentContainer'))
            .toHaveStyle({ display: 'block' }));

        const loadingPane = screen.queryByTestId('fakeLoadingPane');
        const contentContainer = screen.getByTestId('ContentContainer');
        const content = screen.getByTestId('fakeContent');

        expect(loadingPane).not.toBeInTheDocument();
        expect(contentContainer).toHaveStyle({ display: 'block' });
        expect(content).toBeInTheDocument();
    });

    test('it should show spinner', async () => {
        var capturedSpinner:SpinnerManager|null
        const FakeComponent = () => {
            var spinner = useSpinner();
            capturedSpinner = spinner;
            useEffect(() => {
                spinner?.hide();
            }, []);

            return (<div data-testid="fakeContent">Fake Content</div>);
        }
        render(<SpinnerProvider><FakeComponent /></SpinnerProvider>);
        await waitFor(async () => expect(await screen.findByTestId('ContentContainer'))
            .toHaveStyle({ display: 'block' }));

        await act(async () => capturedSpinner?.show());

        await waitFor(() => screen.queryByTestId('fakeLoadingPane'));

        const loadingPane = screen.queryByTestId('fakeLoadingPane');
        const contentContainer = screen.getByTestId('ContentContainer');
        const content = screen.getByTestId('fakeContent');

        expect(loadingPane).toBeInTheDocument();
        expect(contentContainer).toHaveStyle({ display: 'block' });
        expect(content).toBeInTheDocument();
    });

    test('it should show spinner and hide content', async () => {
        var capturedSpinner:SpinnerManager|null = null;
        const FakeComponent = () => {
            var spinner = useSpinner();
            capturedSpinner = spinner;
            useEffect(() => {
                spinner?.hide();
            }, []);

            return (<div data-testid="fakeContent">Fake Content</div>);
        }
        render(<SpinnerProvider><FakeComponent /></SpinnerProvider>);
        await waitFor(async () => expect(await screen.findByTestId('ContentContainer'))
            .toHaveStyle({ display: 'block' }));

        await act(async () => capturedSpinner?.show(true));

        await waitFor(() => screen.queryByTestId('ContentContainer')?.style?.display === 'none');

        const loadingPane = screen.queryByTestId('fakeLoadingPane');
        const contentContainer = screen.getByTestId('ContentContainer');
        const content = screen.getByTestId('fakeContent');

        expect(loadingPane).toBeInTheDocument();
        expect(contentContainer).toHaveStyle({ display: 'none' });
        expect(content).toBeInTheDocument();
    });

    test('it should show spinner with message', async () => {
        var expectedMessage = "Fake Message";
        var capturedSpinner:SpinnerManager|null;
        const FakeComponent = () => {
            var spinner = useSpinner();
            capturedSpinner = spinner;
            useEffect(() => {
                spinner?.hide();
            }, []);

            return (<div data-testid="fakeContent">Fake Content</div>);
        }
        render(<SpinnerProvider><FakeComponent /></SpinnerProvider>);
        await waitFor(async () => expect(await screen.findByTestId('ContentContainer'))
            .toHaveStyle({ display: 'block' }));

        await act(async () => capturedSpinner?.show(false, expectedMessage));

        await waitFor(() => screen.queryByTestId('fakeLoadingPane'));

        const message = screen.getByText(expectedMessage);
        expect(message).toBeInTheDocument();

    });
});