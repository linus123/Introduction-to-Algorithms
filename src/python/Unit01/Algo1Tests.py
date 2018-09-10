import unittest
import algorithms
import peak


class Algo1Tests(unittest.TestCase):

    def test_001(self):
        """
        Should return only value given 1 x 1 grid.
        """
        grid = [
            [1]
        ]

        problem = peak.PeakProblem(grid, (0, 0, 1, 1))

        peek_location = algorithms.algorithm1(problem)

        is_peak = problem.isPeak(peek_location)

        self.assertEqual(True, is_peak)
        self.assertEqual(1, problem.get(peek_location))
        self.assertEqual((0, 0), peek_location)

    def test_002(self):
        """
        Should return only value given 2 x 1 and 1 x 2 grid.
        """
        grid = [
            [2, 2]
        ]

        problem = peak.PeakProblem(grid, (0, 0, 1, 2))
        peek_location = algorithms.algorithm1(problem)
        self.assertEqual(2, problem.get(peek_location))
        is_peak = problem.isPeak(peek_location)

        self.assertEqual(True, is_peak)
        self.assertEqual((0, 1), peek_location)

        grid = [
            [2],
            [2]
        ]

        problem = peak.PeakProblem(grid, (0, 0, 2, 1))
        peek_location = algorithms.algorithm1(problem)
        is_peak = problem.isPeak(peek_location)

        self.assertEqual(True, is_peak)
        self.assertEqual(2, problem.get(peek_location))
        self.assertEqual((0, 0), peek_location)
