import { BASE_URL } from '~/config/config'
import type { PaginationResponse } from '../../types/PaginationResponse'

export const getPokedex = async () => {
  const data = await fetch(`${BASE_URL}?PageNumber=1&PageSize=8`)
  const paginationResponse: PaginationResponse = await data.json()

  return paginationResponse
}
