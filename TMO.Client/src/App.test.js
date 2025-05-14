import { render, screen, fireEvent } from '@testing-library/react';
import { describe, it, test, expect } from '@jest/globals';
import App from './App';

describe('App Component', () => {
    it('renders the heading', () => {
        render(<App />);
        const heading = screen.getByText(/Best Sellers By Branch/i);
        expect(heading).toBeInTheDocument();
    });

    test('renders the select dropdown', () => {
        render(<App />);
        const selectElement = screen.getByRole('combobox');
        expect(selectElement).toBeInTheDocument();
    });

    test('displays selected value when an option is chosen', () => {
        render(<App />);
        const selectElement = screen.getByRole('combobox');
        fireEvent.change(selectElement, { target: { value: 'New York' } });
        const selectedValue = screen.getByText(/Selected value: New York/i);
        expect(selectedValue).toBeInTheDocument();
    });

    test('shows loading indicator initially', () => {
        render(<App />);
        const loadingIndicator = screen.getByText(/Loading.../i);
        expect(loadingIndicator).toBeInTheDocument();
    });
});



