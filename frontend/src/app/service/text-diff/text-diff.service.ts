import { Injectable } from '@angular/core'
import DiffMatchPatch from './diff_match_patch_uncompressed'

@Injectable({
  providedIn: 'root'
})
export class TextDiffService {
  private cache: Map<string, [operation: number, text: string][]> = new Map()

  constructor() { }

  /**
   * This method returns difference between two text.
   * @param before before text
   * @param after after text
   * @returns array of tuple (operation: number, text: string) pair
   */
  diff(before: string, after: string): [operation: number, text: string][] {
    const cacheKey = `${before}::${after}`
    if (this.cache.has(cacheKey)) {
      return this.cache.get(cacheKey)!
    }
    try {
      const dmp = new DiffMatchPatch()
      const diffs = dmp.diff_main(before, after)
      this.cache.set(cacheKey, diffs)
      return diffs
    } catch (error) {
      console.error(error)
    }
  }
}
