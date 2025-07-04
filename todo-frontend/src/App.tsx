import React, { useEffect, useState } from 'react';

interface Todo {
  id: number;
  task: string;
  completed: boolean;
}

function App() {
  const [todos, setTodos] = useState<Todo[]>([]);

  useEffect(() => {
    fetch('https://aturnbtodofunc-hde6a6aceqajd4fy.uksouth-01.azurewebsites.net/api/GetTodos')
      .then((res) => res.json())
      .then((data) => setTodos(data))
      .catch((err) => console.error('Error fetching todos:', err));
  }, []);

  return (
    <div style={{ padding: '20px' }}>
      <h1>My To-Do List</h1>
      <ul>
        {todos.map((todo) => (
          <li key={todo.id}>
            {todo.task} {todo.completed ? '✅' : '❌'}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
