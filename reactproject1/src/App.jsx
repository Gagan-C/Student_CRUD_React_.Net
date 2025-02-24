import { useState } from 'react'
import './App.css'
import CreateStudent from './Components/CreateStudent'
import Students from './Components/Students'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <CreateStudent />
      <Students />
    </>
  )
}

export default App
