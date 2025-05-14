import { useEffect, useState } from 'react'
import './App.css'

function App() {
    const [loading, setLoading] = useState(false)
    const [options, setOptions] = useState([]);
    const [selectedValue, setSelectedValue] = useState('');
    const [performances, setPerformances] = useState([]);

    useEffect(() => {
        try {
            fetch("http://localhost:5139/api/PerformanceReport/getbranches")
                .then(response => response.json())
                .then(data => {
                    // Assuming data is an array of objects with 'id' and 'name' properties
                    console.log(data);
                    setOptions(data);
                })
                .catch(error => {
                    console.error('Error fetching data:', error);
                });

        } catch (error) {
            console.error('Error branch data:', error);
        }

    }, []);


    const handleSelectChange = (event) => {
        setSelectedValue(event.target.value);
    };

    const currencyFormat = (value) => {
        return '$' + value.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
    };

    useEffect(() => {
        try {
            console.log("Selected value:", selectedValue);

            const url = `http://localhost:5139/api/PerformanceReport/bestsellersbybranch/${selectedValue}`;

            if (selectedValue != "") {
                setLoading(true)

                fetch(url)
                    .then(response => response.json())
                    .then(data => {
                        // Assuming data is an array of objects with 'id' and 'name' properties
                        console.log(data);
                        setPerformances(data);

                        setLoading(false)
                    })
                    .catch(error => {
                        console.error('Error fetching data:', error);
                    });
            }
        } catch (error) {
            console.error('Error branch data:', error);
        }

    }, [selectedValue]);



    return (
        <>
            <h2>Top-Performing Seller for Each Month</h2>

            <div>
                <select value={selectedValue} onChange={handleSelectChange}>
                    <option value="" disabled>Select a branch</option>
                    {options.map(option => (
                        <option key={option} value={option}>
                            {option}
                        </option>
                    ))}
                </select>
                <p>Selected branch: {selectedValue}</p>
            </div>

            
            <div className="App">
                {loading ? (
                    <div>Loading...</div>
                ) : (
                    <>
                        <table border={1}>
                            <thead>
                                <tr>
                                    <th>Month</th>
                                    <th>Seller</th>
                                    <th>Total Orders</th>
                                    <th>Total Price</th>
                                </tr>
                            </thead>
                            <tbody>
                                {performances.map(item => (
                                    <tr key={item.month}>
                                        <td>{item.monthName}</td>
                                        <td>{item.seller}</td>
                                        <td className="text-align-right">{item.totalOrder}</td>
                                        <td className="text-align-right">{currencyFormat(item.totalPrice)}</td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </>
                )}
            </div>

        </>
    )
}

export default App
