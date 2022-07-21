type Slice = number[][]

export class Matrix {
  #rows: Slice
  #columns: Slice | null = null

  constructor(input: string) {
    this.#rows = input.split('\n').map(row => row.split(' ').map(Number))
  }

  get rows(): Slice {
    return this.#rows
  }

  get columns(): Slice {
    if (!this.#columns) {
      let columnSize = 0
      this.#rows.forEach(row => {
        if (row.length > columnSize) {
          columnSize = row.length
        }
      })

      this.#columns = []
      for (let i = 0; i < columnSize; i++) {
        this.#columns[i] = []
        this.#rows.forEach(row => {
          this.#columns![i].push(row[i])
        })
      }
    }

    return this.#columns
  }
}
