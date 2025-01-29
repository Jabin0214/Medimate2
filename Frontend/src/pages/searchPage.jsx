import React, { useState } from "react";
import { search } from "../api/apiClient";
import axiosInstance from "../api/axiosInstance";

const SearchPage = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [results, setResults] = useState([]);
  const [error, setError] = useState(null);

  const handleFormSubmit = async (event) => {
      event.preventDefault();
    setResults([]);
    axiosInstance.get('/Drugs/search?name=swiss')
      .then(response => console.log("API Response:", response.data))
      .catch(error => console.error("API Error:", error));
    try {
      const data = await search(searchTerm);
      setResults(data);
      setError(null);
    } catch (err) {
      setError(err.response?.data || "An error occurred.");
      setResults([]);
    }
  };

  return (
    <div className="max-w-md mx-auto">
      <form onSubmit={handleFormSubmit} className="mb-4 mt-10">
        <input
          type="search"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          placeholder="Search Products..."
          className="w-full p-4 border rounded-lg text-sm"
          required
        />
        <button
          type="submit"
          className="mt-2 w-full bg-blue-700 text-white py-2 rounded-lg hover:bg-blue-800"
        >
          Search
        </button>
      </form>
      {error && <p className="text-red-500">{error}</p>}
      <ul>
        {results.map((result) => (
          <li key={result.id} className="mb-4 border p-4 rounded-lg shadow">
            <h2 className="font-bold text-lg">{result.name}</h2>
            {result.images && (
              <img src={result.images} alt={result.name} className="mb-2 rounded" />
            )}
            <p><strong>Price:</strong> ${result.price}</p>
            <p><strong>Description:</strong> {result.description}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default SearchPage;