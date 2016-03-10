        /// <summary>
        ///     # Run algorithm 1 in "Finding the circle that best fits a set of points" (2007) by L Maisonbobe, found at
        ///     # http://www.spaceroots.org/documents/circle/circle-fitting.pdf
        /// </summary>
        /// <param name="pts">A list of points</param>
        /// <param name="epsilon">A floating point value, if abs(delta) between a set of three points is less than this value, the set will
        /// be considered aligned and be omitted from the fit</param>
        /// <returns></returns>
        public static PointF FitCenter(List<PointF> pts, double epsilon = 0.1)
        {
            double totalX = 0, totalY = 0;
            int setCount = 0;

            for (int i = 0; i < pts.Count; i++)
            {
                for (int j = 1; j < pts.Count; j++)
                {
                    for (int k = 2; k < pts.Count; k++)
                    {
                        double delta = (pts[k].X - pts[j].X) * (pts[j].Y - pts[i].Y) - (pts[j].X - pts[i].X) * (pts[k].Y - pts[j].Y);

                        if (Math.Abs(delta) > epsilon)
                        {
                            double ii = Math.Pow(pts[i].X, 2) + Math.Pow(pts[i].Y, 2);
                            double jj = Math.Pow(pts[j].X, 2) + Math.Pow(pts[j].Y, 2);
                            double kk = Math.Pow(pts[k].X, 2) + Math.Pow(pts[k].Y, 2);

                            double cx = ((pts[k].Y - pts[j].Y) * ii + (pts[i].Y - pts[k].Y) * jj + (pts[j].Y - pts[i].Y) * kk) / (2 * delta);
                            double cy = -((pts[k].X - pts[j].X) * ii + (pts[i].X - pts[k].X) * jj + (pts[j].X - pts[i].X) * kk) / (2 * delta);

                            totalX += cx;
                            totalY += cy;

                            setCount++;
                        }
                    }
                }
            }

            if (setCount == 0)
            {
                //failed
                return PointF.Empty;
            }



            return new PointF((float)totalX / setCount, (float)totalY / setCount);
        }
