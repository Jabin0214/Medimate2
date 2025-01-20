import React, { useState } from "react";
import { search } from "../../Frontend/api/apiClient"; // 确保路径正确

const App = () => {
  const [searchTerm, setSearchTerm] = useState("");
  const [results, setResults] = useState([]);
  const [error, setError] = useState(null);

  const handleSearchChange = (event) => {
    setSearchTerm(event.target.value); // 更新搜索框的值
  };

  const handleFormSubmit = async (event) => {
    event.preventDefault(); // 阻止表单默认提交行为
    try {
      const data = await search(searchTerm); // 调用 API 请求
      setResults(data); // 将返回的数据存入状态
      setError(null); // 清除可能的错误
    } catch (err) {
      setError("An error occurred while fetching data.");
      console.error(err);
    }
  };

  return (
    <div className="max-w-md mx-auto">
      <form onSubmit={handleFormSubmit} className="mb-4">
        <label
          htmlFor="default-search"
          className="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white"
        >
          Search
        </label>
        <div className="relative">
          <input
            type="search"
            id="default-search"
            value={searchTerm}
            onChange={handleSearchChange}
            className="block w-full p-4 ps-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            placeholder="Search Mockups, Logos..."
            required
          />
          <button
            type="submit"
            className="text-white absolute end-2.5 bottom-2.5 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800"
          >
            Search
          </button>
        </div>
      </form>
      {error && <p className="text-red-500">{error}</p>}
      <ul>
        {results.map((result) => (
          <li key={result.id}>
            <h2>{result.name}</h2>
            <p>Price: ${result.price}</p>
            <p>Description: {result.description}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default App;